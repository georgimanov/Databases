namespace CompanySampleDataImporter.Importer
{
    using System;

    class StartUp
    {
        static void Main()
        {
            // 2:07:05
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}