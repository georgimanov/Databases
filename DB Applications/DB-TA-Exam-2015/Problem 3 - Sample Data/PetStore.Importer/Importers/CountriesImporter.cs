namespace PetStore.Importer.Importers
{
    using PetStore.Data;
    using PetStore.Importer.Importers.Contracts;

    using System;
    using System.IO;

    public class CountriesImporter : IImporter
    {
        private const int NumberOfCountries = 20;

        public string Message
        {
            get { return "Importing countries"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<PetStoreEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {

                    for (int i = 0; i < NumberOfCountries; i++)
                    {
                        db.Countries.Add(new Country()
                        {
                            Name = RandomGenerator.GetRandomString(5, 50),
                        });

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
