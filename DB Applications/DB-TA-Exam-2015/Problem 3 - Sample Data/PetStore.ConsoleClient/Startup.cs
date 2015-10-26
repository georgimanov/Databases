namespace PetStore.ConsoleClient
{
    using System;

    using PetStore.Importer;

    public class Startup
    {
        public static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
