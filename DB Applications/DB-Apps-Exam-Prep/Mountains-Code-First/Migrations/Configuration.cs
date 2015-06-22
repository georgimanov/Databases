namespace Mountains_Code_First.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mountains_Code_First.MountainsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MountainsContext context)
        {
            if (!context.Countries.Any())
            {
                Country bulgaria = new Country()
                {
                    Code = "BG",
                    Name = "Bulgaria"
                };

                context.Countries.Add(bulgaria);
                context.SaveChanges();

                Mountain rila = new Mountain()
                {
                    Name = "Rila",
                };

                context.Mountains.Add(rila);
                context.SaveChanges();

                bulgaria.Mountains.Add(rila);

                Peak musala = new Peak()
                {
                    Name = "Musala",
                    MountainId = rila.Id,
                    Elevation = 2925,
                };

                context.Peaks.Add(musala);

                context.SaveChanges();
            }
        }
    }
}
