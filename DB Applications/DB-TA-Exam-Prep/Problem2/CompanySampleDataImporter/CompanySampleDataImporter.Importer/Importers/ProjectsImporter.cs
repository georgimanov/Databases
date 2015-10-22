namespace CompanySampleDataImporter.Importer.Importers
{
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers.Contracts;
    using System;
    using System.IO;
    using System.Linq;

    public class ProjectsImporter : IImporter
    {
        private const int NumberOfProjects = 100; // 100

        public string Message
        {
            get
            {
                return "Importing projects";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                    {
                        var allEmployeeIds =
                            db
                            .Employees
                            .OrderBy(e => Guid.NewGuid())
                            .Select(e => e.Id)
                            .ToList();

                        var currentEmployeeindex = 0;
                        for (int i = 0; i < NumberOfProjects; i++)
                        {
                            var currentProject = new Projects()
                            {
                                Name = RandomGenerator.GetRandomString(5, 50)
                            };

                            var numberEmployeesPerProject = RandomGenerator.GetRandomNumber(2, 8);
                            var startDate = RandomGenerator.GetRandomDateTime(before: DateTime.Now.AddDays(-100));
                            var endDate = RandomGenerator.GetRandomDateTime(after: startDate);
                            for (int j = 0; j < numberEmployeesPerProject; j++)
                            {
                                if (j + currentEmployeeindex >= allEmployeeIds.Count)
                                {
                                    break;
                                }
                                
                                var currentEmployeeId = allEmployeeIds[currentEmployeeindex];

                                currentProject.ProjectsEmployees
                                    .Add(
                                    new ProjectsEmployees()
                                        {
                                            EmployeeId = currentEmployeeId,
                                            StartDate = startDate,
                                            EndDate = endDate
                                        });

                                currentEmployeeindex++;
                            }

                            db.Projects.Add(currentProject);

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
