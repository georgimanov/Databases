using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export_Photographs_as_XML
{
    using System.Xml.Linq;
    using Photography;
    class ExportPhotographAsXML
    {
        static void Main(string[] args)
        {
            var context = new PhotographyEntities();

            var photosQuery = context.Photographs
                .OrderBy(p => p.Title)
                .Select(p => new
                {
                    Title = p.Title,
                    Category = p.Category.Name,
                    Link = p.Link,
                    EquipmentCameras = p.Equipment.Camera,
                    EquipmentLens = p.Equipment.Lens,
                });

            var xmlDoc = new XDocument();
            var xmlRoot = new XElement("photographs");
            xmlDoc.Add(xmlRoot);

            foreach (var photo in photosQuery)
            {
                var photoXML = new XElement("photograph", new XAttribute("title", photo.Title));
                xmlRoot.Add(photoXML);

                var categoryXML = new XElement("category", photo.Category);
                var linkXml = new XElement("link", photo.Link);
                photoXML.Add(categoryXML);
                photoXML.Add(linkXml);

                var equipmentXML = new XElement("equipment");
                photoXML.Add(equipmentXML);

                var cameraXML = new XElement("camera", photo.EquipmentCameras.Model, new XAttribute("megapixels", photo.EquipmentCameras.Megapixels));
                equipmentXML.Add(cameraXML);

                var lensXML = new XElement("lens", photo.EquipmentLens.Model);
                if (photo.EquipmentLens.Price != null)
                {
                    var attr = new XAttribute("price", photo.EquipmentLens.Price);
                    lensXML.Add(attr);
                }

                equipmentXML.Add(lensXML);
            }

            xmlDoc.Save(@"../../photographs.xml");
        }
    }
}
