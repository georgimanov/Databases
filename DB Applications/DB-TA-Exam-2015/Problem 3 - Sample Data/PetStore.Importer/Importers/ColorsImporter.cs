namespace PetStore.Importer.Importers
{
    using System;
    using System.IO;

    using PetStore.Data;
    using PetStore.Importer.Enum;
    using PetStore.Importer.Importers.Contracts;

    public class ColorsImporter : IImporter
    {
        private const int NumberOfColors = 4;

        public string Message
        {
            get { return "Importing colors"; }
        }

        public int Order
        {
            get { return 1; }
        }

        public Action<PetStoreEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    foreach (Colors color in Enum.GetValues(typeof(Colors)))
                    {
                        db.Colors.Add(new Color() { Name = color.ToString() });
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
