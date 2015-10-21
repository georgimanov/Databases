namespace CompanySampleDataImporter.Importer.Importers
{
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers.Contracts;
    using System;
    using System.IO;

    public class DepartmentsImporter : IImporter
    {
        private const int NumberOfDepartments = 100;

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
                            Name = RandomGenerator.GetRandomString(10, 50),
                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
