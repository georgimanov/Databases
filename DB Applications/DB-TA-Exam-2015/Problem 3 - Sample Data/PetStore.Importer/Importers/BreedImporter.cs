namespace PetStore.Importer.Importers
{
    using System;

    using PetStore.Data;
    using PetStore.Importer.Importers.Contracts;

    public class BreedImporter : IImporter
    {
        private const int NumberOfBreeds = 20;

        public string Message
        {
            get { return "Importing breeds"; }
        }

        public int Order
        {
            get { return 4; }
        }

        public Action<Data.PetStoreEntities, System.IO.TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {

                    for (int i = 0; i < NumberOfBreeds; i++)
                    {
                        db.Breeds.Add(new Breed
                        {
                            Name = RandomGenerator.GetRandomString(5, 30),
                        });

                        if (i%10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i%100 == 0)
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
