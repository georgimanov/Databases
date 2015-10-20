namespace CompanySampleDataImporter.Importer.Importers.Contracts
{
    using System;
    using System.IO;

    using CompanySampleDataImporter.Data;

    public interface IImporter
    {
        string Message { get; }

        int Order { get; }
        
        Action<CompanyEntities, TextWriter> Get { get; }
    }
}
