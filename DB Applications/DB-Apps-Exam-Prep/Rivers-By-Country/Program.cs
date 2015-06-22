using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Rivers_By_Country
{
    using EF_Mapping;
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var riversQuery = context.Rivers.AsQueryable();

            var xmlDoc = XDocument.Load("../../rivers-query.xml");
            foreach (var queryElement in xmlDoc.XPathSelectElements("/queries/query"))
            {
                foreach (var countryElement in queryElement.XPathSelectElements("country"))
                {
                    var countryName = countryElement.Value;

                    riversQuery = riversQuery
                        .Where(
                            r => r.Countries.Any(c => c.CountryName == countryName)
                    );
                }

                riversQuery = riversQuery.OrderBy(r => r.RiverName);
                var maxResultsAttribute = queryElement.Attribute("max-results");
                if (maxResultsAttribute != null)
                {
                    int maxResults = int.Parse(maxResultsAttribute.Value);

                    riversQuery = riversQuery.Take(maxResults);
                }

                var riverNames = riversQuery.Select(r => r.RiverName);

                Console.WriteLine(string.Join(", ", riverNames));
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
