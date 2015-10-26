namespace PetStore.Importer.Importers
{
    using System;

    using PetStore.Data;
    using PetStore.Importer.Importers.Contracts;

    public class CategoriesImporter : IImporter
    {
        private const int NumberOfCategories = 50;

        public string Message
        {
            get { return "Importing categories"; }
        }

        public int Order
        {
            get { return 6; }
        }

        public Action<Data.PetStoreEntities, System.IO.TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {

                    for (int i = 0; i < NumberOfCategories; i++)
                    {
                        db.Categories.Add(new Category()
                        {
                            Name = RandomGenerator.GetRandomString(5, 20),
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
