using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Random_Equipment
{
    using System.Runtime.InteropServices;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Photography;
    class GenerateRandomEquipment
    {
        static void Main(string[] args)
        {
            var defaultGenerateCount = 10;
            var context = new PhotographyEntities();
            var defaultManufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Nikon");

            var xmlDoc = XDocument.Load("../../generate-equipments.xml");
            //var photographyElements = xmlDoc.Root.Elements();
            var generateElements = xmlDoc.XPathSelectElements("/generate-random-equipments/generate");

            var camerasIds = context.Cameras.Select(c => new { id = c.Id }).ToList();
            var lensesIds = context.Lenses.Select(l => new { id = l.Id }).ToList();

            var count = 1;

            foreach (var element in generateElements)
            {
                Console.WriteLine("Processing request #{0} ...", count++);


                var currentManufacturer = defaultManufacturer;
                if (!string.IsNullOrEmpty(element.Value))
                {
                    currentManufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == element.Value);
                }

                var currentGenerateCount = defaultGenerateCount;
                if (element.HasAttributes)
                {
                    currentGenerateCount = int.Parse(element.Attribute("generate-count").Value);
                }

                for (int i = 0; i < currentGenerateCount; i++)
                {
                    var random = new Random();
                    var randomCameraId = camerasIds[random.Next(1, camerasIds.Count)];
                    var randomLensId = lensesIds[random.Next(1, lensesIds.Count)];

                    var camera = context.Cameras.FirstOrDefault(c => c.Id == randomCameraId.id);
                    var lens = context.Lenses.FirstOrDefault(c => c.Id == randomLensId.id);

                    Console.WriteLine(
                        "Equipment added: {0} (Camera: {1} - Lens: {2})", 
                        currentManufacturer.Name, 
                        camera.Model, 
                        lens.Model);

                    if (!currentManufacturer.Cameras.Contains(camera))
                    {
                        currentManufacturer.Cameras.Add(camera);
                    }

                    if (!currentManufacturer.Lenses.Contains(lens))
                    {
                        currentManufacturer.Lenses.Add(lens);
                    }
                }

                context.SaveChanges();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
