namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Collections.Generic;

    using CompanySampleDataImporter.Importer.Importers.Contracts;
    using CompanySampleDataImporter.Data;
    using System.IO;
    using System.Linq;

    public class ManagersImporter : IImporter
    {
        public string Message
        {
            get { return "Importing manager id(s)"; }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                    {
                        // levelsSum == 100 => true
                        var levels = new[] { 5, 5, 10, 10, 10, 15, 15, 15, 15 };

                        // Returns all ids in random order
                        var allEmpoyeeIds = db
                            .Employees
                            .OrderBy(e => Guid.NewGuid())
                            .Select(e => e.Id)
                            .ToList();

                        var currentPercentage = 0;
                        List<int> previousManagers = null;
                        foreach (var level in levels)
                        {
                            var skip = (int)((currentPercentage * allEmpoyeeIds.Count) / 100.0);
                            var take = (int)((level * allEmpoyeeIds.Count) / 100.0);

                            var currentEmployeeIds = allEmpoyeeIds
                                .Skip(skip)
                                .Take(take)
                                .ToList();

                            var employees = db
                                .Employees
                                .Where(e => currentEmployeeIds.Contains(e.Id))
                                .ToList();

                            foreach (var employee in employees)
                            {
                                employee.ManagerId = previousManagers == null
                                                         ? null
                                                         : (int?)previousManagers[
                                                             RandomGenerator.GetRandomNumber(0, previousManagers.Count - 1)];
                            }

                            tr.Write(".");
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();

                            previousManagers = currentEmployeeIds;

                            currentPercentage += level;
                        }
                    };
            }
        }
    }
}
