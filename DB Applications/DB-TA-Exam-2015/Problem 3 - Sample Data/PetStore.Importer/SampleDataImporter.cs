namespace PetStore.Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using PetStore.Data;
    using PetStore.Importer.Importers.Contracts;

    public class SampleDataImporter
    {
        private TextWriter textWriter;

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .OfType<IImporter>()
                .OrderBy(t => t.Order)
                .ToList()
                .ForEach(i =>
                {
                    this.textWriter.Write(i.Message);
                    var db = new PetStoreEntities();
                    i.Get(db, this.textWriter);

                    this.textWriter.WriteLine();
                });
        }
    }
}
