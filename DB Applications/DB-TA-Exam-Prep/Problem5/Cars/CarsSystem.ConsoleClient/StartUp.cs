namespace CarsSystem.ConsoleClient
{
    using System.Data.Entity;

    using CarsSystem.Data;
    using CarsSystem.Data.Migrations;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>
            // new DropCreateDatabaseAlways<CarsSystemDbContext>()
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>());

            // JsonCarsImporter.Import();

            XmlCarsSearcher.Search();
        }
    }
}
