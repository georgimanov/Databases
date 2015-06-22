using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Import_Rivers_From_XML
{
    using EF_Mapping;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var xmlDoc = XDocument.Load("../../rivers.xml");
            var riverElements = xmlDoc.Root.Elements();

            foreach (var riverElement in riverElements)
            {
                var riverEntity = new River();

                riverEntity.RiverName = riverElement.Element("name").Value;
                riverEntity.Length = int.Parse(riverElement.Element("length").Value);
                riverEntity.Outflow = riverElement.Element("outflow").Value;

                if (riverElement.Element("average-discharge") != null)
                {
                    riverEntity.AverageDischarge = int.Parse(riverElement.Element("average-discharge").Value);

                }

                if (riverElement.Element("drainage-area") != null)
                {
                    riverEntity.DrainageArea = int.Parse(riverElement.Element("drainage-area").Value);
                }

                var countryElements = riverElement.XPathSelectElements("countries/contry");

                foreach (var countryElement in countryElements)
                {
                    var countryName = countryElement.Value;
                    var countryEntity = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    if (countryEntity != null)
                    {
                        riverEntity.Countries.Add(countryEntity);
                    }
                    else
                    {
                        throw new Exception(String.Format("Cannot find {0} in the DB", countryName));
                    }
                }
                context.Rivers.Add(riverEntity);
            }
            context.SaveChanges();
        }
    }
}
