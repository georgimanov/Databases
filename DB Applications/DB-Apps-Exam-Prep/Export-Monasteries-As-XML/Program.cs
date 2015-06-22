using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Export_Monasteries_As_XML
{
    using EF_Mapping;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var countriesQuery = context
                .Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    countryName = c.CountryName,
                    Monasteries = c.Monasteries
                        .OrderBy(m => m.Name)
                        .Select(m => m.Name)
                });

            var xmlDoc = new XDocument();
            var xmlRoot = new XElement("monasteries");

            xmlDoc.Add(xmlRoot);

            foreach (var country in countriesQuery)
            {
                var countryXML = new XElement("country", new XAttribute("name", country.countryName));
                xmlRoot.Add(countryXML);

                foreach (var monastery in country.Monasteries)
                {
                    var monasteryXML = new XElement("monastery", monastery);
                    countryXML.Add(monasteryXML);
                }
            }

            xmlDoc.Save("monasteries.txt");
        }
    }
}
