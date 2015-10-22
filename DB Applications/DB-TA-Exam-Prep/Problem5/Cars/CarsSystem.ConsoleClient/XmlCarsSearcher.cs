namespace CarsSystem.ConsoleClient
{
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using CarsSystem.ConsoleClient.Models;
    using CarsSystem.Data;

    public static class XmlCarsSearcher
    {
        public static void Search()
        {
            var xmlQueries = Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/XmlFiles/")
                .Where(f => f.EndsWith(".xml"))
                .Select(File.ReadAllText)
                .FirstOrDefault();

            var stringReader = new StringReader(xmlQueries);

            var serializer = (Queries)new XmlSerializer(typeof(Queries)).Deserialize(stringReader);

            foreach (var query in serializer.Query)
            {
                ProcessQuery(query);
            }
        }

        private static void ProcessQuery(QueriesQuery query)
        {
            var db = new CarsSystemDbContext();

            var carsQuery = db.Cars.AsQueryable();

            foreach (var whereClauses in query.WhereClauses)
            {
                switch (whereClauses.PropertyName)
                {
                    case "Year":
                        switch (whereClauses.Type)
                        {
                            case "Equals":
                                carsQuery = carsQuery.Where(c => c.Id == int.Parse(whereClauses.Value)); break;
                            case "GreaterThan":
                                carsQuery = carsQuery.Where(c => c.Id > int.Parse(whereClauses.Value)); break;
                            case "LessThan":
                                carsQuery = carsQuery.Where(c => c.Id < int.Parse(whereClauses.Value)); break;
                        }
                        break;
                    case "Model":
                        break;
                    case "Price":
                        break;
                    case "Manufacturer":
                        break;
                    case "Dealer":
                        break;
                    default: break;
                }
            }

            switch (query.OrderBy)
            {
                case "Year":
                    carsQuery = carsQuery.OrderBy(c => c.Year);
                    break;
                case "Model":
                    carsQuery = carsQuery.OrderBy(c => c.Model);
                    break;
                case "Price":
                    carsQuery = carsQuery.OrderBy(c => c.Price);
                    break;
                case "Manufacturer":
                    carsQuery = carsQuery.OrderBy(c => c.Manufacturer.Name);
                    break;
                case "Dealer":
                    carsQuery = carsQuery.OrderBy(c => c.Dealer.Name);
                    break;
                default: break;
            }
        }
    }
}
