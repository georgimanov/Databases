namespace PetStore.Importer.Importers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using PetStore.Importer.Importers.Contracts;
    using PetStore.Data;
    using System.IO;
    using System.Linq;

    public class ProductsImporter : IImporter
    {
        private const int NumberOfProducts = 20000;

        public string Message
        {
            get { return "Importing pet products"; }
        }

        public int Order
        {
            get { return 3; }
        }

        public Action<PetStoreEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var allCategoriesIds = db
                        .Categories
                        .OrderBy(c => Guid.NewGuid())
                        .Select(c => c.Id)
                        .ToList();

                    var allCountriesIds = db
                       .Countries
                       .OrderBy(c => Guid.NewGuid())
                       .Select(c => c.Id)
                       .ToList();

                    var categoryIndex = 0;
                    for (int i = 0; i < NumberOfProducts; i++)
                    {
                        var productToAdd = new PetProduct()
                        {
                            Price = RandomGenerator.GetRandomNumber(10, 1000),
                            Name = RandomGenerator.GetRandomString(5, 25),
                        };

                        if (categoryIndex >= (allCategoriesIds.Count - 1))
                        {
                            categoryIndex = 0;
                        }
                        categoryIndex++;
                        productToAdd.CategoryId = allCategoriesIds[categoryIndex];


                        var numberOfSpecies = RandomGenerator.GetRandomNumber(2, 10);

                        for (int j = 0; j < numberOfSpecies; j++)
                        {
                            var randomCountryIndex = RandomGenerator.GetRandomNumber(0, allCountriesIds.Count - 1);
                            var randomCountryId = allCountriesIds[randomCountryIndex];
                            var specie = new Species()
                            {
                                Name = RandomGenerator.GetRandomString(5, 50),
                                OriginCountryId = randomCountryId
                            };

                            productToAdd.Species.Add(specie);
                        }

                        db.PetProducts.Add(productToAdd);

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new PetStoreEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
