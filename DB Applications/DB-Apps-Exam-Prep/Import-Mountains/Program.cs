using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Mountains_Code_First;

namespace Import_Mountains
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MountainsContext();

            var json = File.ReadAllText(@"..\..\mountains.json");
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var mountains  = ser.Deserialize<MountainsDto[]>(json);

            foreach (var mountainsDto in mountains)
            {
                var mountain = new Mountain();
                mountain.Name = mountainsDto.MountainName;

                context.Mountains.Add(mountain);

                foreach (var peakDto in mountainsDto.Peaks)
                {
                    var peak = new Peak();
                    peak.Name = peakDto.PeakName;
                    peak.Elevation = peakDto.Elevation;

                    mountain.Peaks.Add(peak);
                }

                foreach (var countryNameDto in mountainsDto.Countries)
                {
                    var country = context.Countries.FirstOrDefault(c => c.Name == countryNameDto);

                    if (country == null)
                    {
                        country = new Country()
                        {
                            Code = new String(countryNameDto.ToUpper().Take(2).ToArray()),
                            Name = countryNameDto
                        };
                    }

                    mountain.Countries.Add(country);
                }

                context.SaveChanges();
            }



        }
    }
}
