namespace PetStore.Importer.Importers
{
    using System;
    using System.Linq;

    using PetStore.Importer.Importers.Contracts;
    using System.IO;

    using PetStore.Data;

    public class PetsImporter : IImporter
    {
        private const int NumberOfPets = 5000; 

        public string Message
        {
            get { return "Importing pets"; }
        }

        public int Order
        {
            get { return 5; }
        }

        public Action<PetStoreEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var breedIds = db
                        .Breeds
                        .Select(d => d.Id)
                        .ToList();

                    var allSpecieIds = db
                        .Species
                        .OrderBy(s => Guid.NewGuid())
                        .Select(s => s.Id)
                        .ToList();

                    var petColorIds = db
                        .Colors
                        .Select(c => c.Id)
                        .ToList();

                    var speciesIndex = 0;
                    for (int i = 0; i < NumberOfPets; i++)
                    {
                        if (speciesIndex >= (allSpecieIds.Count - 1))
                        {
                            speciesIndex = 0;
                        }
                        var specieId = allSpecieIds[speciesIndex];
                        speciesIndex++;

                        var randomColorIndex = RandomGenerator.GetRandomNumber(0, petColorIds.Count - 1);
                        var petColorId = petColorIds[randomColorIndex];

                        var petToAdd = new Pet()
                        {
                            BirthDate = RandomGenerator.GetRandomDateTime(),
                            ColorId = petColorId,
                            Price = RandomGenerator.GetRandomNumber(5, 2500),
                            SpecieId = specieId
                        };

                        if (RandomGenerator.GetRandomNumber(0, 100) > 90)
                        {
                            var randomBreedIndex = RandomGenerator.GetRandomNumber(0, breedIds.Count - 1);
                            var breedId = breedIds[randomBreedIndex];
                            petToAdd.BreedId = breedId;
                        }

                        db.Pets.Add(petToAdd);

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
