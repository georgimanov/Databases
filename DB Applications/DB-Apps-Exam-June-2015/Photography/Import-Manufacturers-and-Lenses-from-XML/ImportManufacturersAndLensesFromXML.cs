using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_Manufacturers_and_Lenses_from_XML
{
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Photography;
    class ImportManufacturersAndLensesFromXML
    {
        static void Main(string[] args)
        {
            var context = new PhotographyEntities();
            var xmlDoc = XDocument.Load("../../manufacturers-and-lenses.xml");
            //var photographyElements = xmlDoc.Root.Elements();
            var photographyElements = xmlDoc.XPathSelectElements("/manufacturers-and-lenses/manufacturer");

            var count = 1;
            foreach (var photographyElement in photographyElements)
            {
                Console.WriteLine("Processing manufacturer #{0} ...", count++);

                var manufacturerName = photographyElement.Element("manufacturer-name").Value;
                var manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer();
                    manufacturer.Name = manufacturerName;
                    context.Manufacturers.Add(manufacturer);
                    Console.WriteLine("Created manufacturer: {0}", manufacturerName);
                }
                else
                {
                    Console.WriteLine("Existing manufacturer: {0}", manufacturerName);
                }

                var lenses = photographyElement.XPathSelectElements("lenses/lens");
                foreach (var lens in lenses)
                {
                    var lensModel = lens.Attribute("model").Value;

                    var lensEntity = context.Lenses.FirstOrDefault(l => l.Model == lensModel);
                    if (lensEntity == null)
                    {
                        lensEntity = new Lens();
                        lensEntity.Model = lensModel;

                        var lensType = lens.Attribute("type").Value;
                        lensEntity.Type = lensType;

                        if (lens.Attribute("price") != null)
                        {
                            var lensPrice = lens.Attribute("price").Value;
                            lensEntity.Price = decimal.Parse(lensPrice);
                        }

                        context.Lenses.Add(lensEntity);
                        Console.WriteLine("Created lens {0}", lensModel);
                    }
                    else
                    {
                        Console.WriteLine("Existing lens: {0}", lensModel);
                    }

                    manufacturer.Lenses.Add(lensEntity);
                }

                context.SaveChanges();
                Console.WriteLine();
            }
        }
    }
}
