namespace CompanySampleDataImporter.Importer.Importers
{
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers.Contracts;
    using System;
    using System.IO;

    public class EmployeesImporter : IImporter
    {
        public string Message
        {
            get { return "Importing employees"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
