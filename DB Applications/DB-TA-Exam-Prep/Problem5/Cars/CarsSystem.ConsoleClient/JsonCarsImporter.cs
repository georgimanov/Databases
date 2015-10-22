namespace CarsSystem.ConsoleClient
{
    using System;
    using System.IO;
    using System.Linq;

    using CarsSystem.ConsoleClient.Models;

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Diagnostics;

    using CarsSystem.Data;

    using CarSystem.Models;

    public static class JsonCarsImporter
    {
        public static void Import()
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var carsToAdd = Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/Data.Json.Files/")
                .Where(f => f.EndsWith(".json"))
                .Select(File.ReadAllText)
                .SelectMany(JsonConvert.DeserializeObject<IEnumerable<JsonCarModel>>)
                .ToList();

            var addedCities = new HashSet<string>();
            var addedManufacturers = new HashSet<string>();

            Console.WriteLine("Adding cars");

            var addedCars = 0;
            var db = new CarsSystemDbContext();

            // OPTIMIZATION?
            // db.Configuration.AutoDetectChangesEnabled = false;
            // db.Configuration.ValidateOnSaveEnabled = false;

            foreach (var car in carsToAdd)
            {
                var cityName = car.Dealer.City;
                if (!addedCities.Contains(cityName))
                {
                    addedCities.Add(cityName);
                    db.Cities.Add(new City() {Name = cityName});
                    db.SaveChanges();
                }

                var dbCityToAdd = db.Cities.FirstOrDefault(c=> c.Name == cityName);

                var manufacturer = car.ManufacturerName;
                if (!addedManufacturers.Contains(manufacturer))
                {
                    addedManufacturers.Add(manufacturer);
                    db.Manufacturers.Add(new Manufacturer() {Name = manufacturer});
                    db.SaveChanges();
                }

                var manufacturerToAdd = db.Manufacturers.FirstOrDefault(m => m.Name == manufacturer);

                var dealerToAdd = new Dealer()
                {
                    Name = car.Dealer.Name
                };

                var carToAdd = new Car()
                {
                    Manufacturer = manufacturerToAdd,
                    Dealer = dealerToAdd,
                    Model = car.Model,
                    Price = car.Price,
                    TransmissionType = (TransmissionType)car.TransmissionType,
                    Year = car.Year
                };

                db.Cars.Add(carToAdd);

                addedCars++;

                if (addedCars % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new CarsSystemDbContext();

                    // OPTIMIZATION?
                    // db.Configuration.AutoDetectChangesEnabled = false;
                    // db.Configuration.ValidateOnSaveEnabled = false;
                }

                if (addedCars % 1000 == 0)
                {
                    Console.WriteLine(addedCars + " ");
                }
            }
            db.SaveChanges();

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
