using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export_Manufacturer_As_JSON
{
    using Photography;
    using System.Web.Script.Serialization;

    class ExportManufacturers
    {
        static void Main(string[] args)
        {
            var context = new PhotographyEntities();

            var manufacturersQuery = context.Manufacturers
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                    manufacturer = m.Name,
                    cameras = m.Cameras
                    .OrderBy(c => c.Model)
                    .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                });

            var json = new JavaScriptSerializer().Serialize(manufacturersQuery.ToList());

            System.IO.File.WriteAllText(@"..\..\manufactureres-and-cameras.json", json);
        }
    }
}
