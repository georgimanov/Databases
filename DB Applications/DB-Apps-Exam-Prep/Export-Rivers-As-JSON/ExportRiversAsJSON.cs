using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export_Rivers_As_JSON
{
    using EF_Mapping;
    using System.Web.Script.Serialization;

    public class ExportRiversAsJSON
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var rivers = context
                .Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLenght = r.Length,
                    countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)
                });

            var json = new JavaScriptSerializer().Serialize(rivers.ToList());
            
            Console.WriteLine(json);

            System.IO.File.WriteAllText(@"..\..\riversAsJSON.txt", json);
        }
    }
}
