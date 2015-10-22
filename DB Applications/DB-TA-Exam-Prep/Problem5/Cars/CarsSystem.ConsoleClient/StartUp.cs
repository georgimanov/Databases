namespace CarsSystem.ConsoleClient
{
    using System.Data.Entity;
    using System.Linq;

    using CarsSystem.Data;
    using CarsSystem.Data.Migrations;

    using CarSystem.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>());

            var db = new CarsSystemDbContext();

            db.Cars.Count();
        }
    }
}
