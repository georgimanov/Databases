namespace CompanySampleDataImporter.Importer.Importers
{
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers.Contracts;
    using System;
    using System.IO;

    public class DepartmentsImporter : IImporter
    {
        private const int NumberOfDepartments = 10; // 100

        public string Message
        {
            get { return "Importing departments"; }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < NumberOfDepartments; i++)
                    {
                        db.Departments.Add(new Departments()
                        {
                            
                        });
                    }
                };
            }
        }
    }
}
