namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.IO;
    using System.Linq;

    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers.Contracts;

    class ReportsImporter : IImporter
    {
        public string Message
        {
            get { return "Importing reports"; }
        }

        public int Order
        {
            get { return 5; }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                    {
                        var employeeIds = db.Employees.Select(e => e.Id).ToList();


                        for (int i = 0; i < employeeIds.Count; i++)
                        {
                            var numberOfReports = RandomGenerator.GetRandomNumber(25, 75);
                            for (int j = 0; j < numberOfReports; j++)
                            {

                                db.Reports.Add(new Reports()
                                {
                                    EmployeeId = employeeIds[i],
                                    Time = RandomGenerator.GetRandomDateTime(before: DateTime.Now),
                                });
                            }

                            tr.Write(".");

                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    };
            }
        }
    }
}
