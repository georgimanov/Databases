namespace CompanySampleDataImporter.Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers.Contracts;

    public class SampleDataImporter
    {
        private TextWriter _textWriter;

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        private SampleDataImporter(TextWriter textWriter)
        {
            this._textWriter = textWriter;
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
                    this._textWriter.Write(i.Message);
                    var db = new CompanyEntities();
                    i.Get(db, this._textWriter);

                    this._textWriter.WriteLine();
                });
        }
    }
}
