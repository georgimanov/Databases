using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography
{
    class ListCameras
    {
        static void Main(string[] args)
        {
            var context = new PhotographyEntities();

            var camerasQuery = context.Cameras
                .OrderBy(c => c.Manufacturer.Name)
                .ThenBy(c => c.Model)
                .Select(c => new
                {
                    Name = c.Manufacturer.Name,
                    Model = c.Model
                });

            foreach (var camera in camerasQuery)
            {
                Console.WriteLine(camera.Name + " " + camera.Model);
            }

            Console.ReadLine();
        }
    }
}
