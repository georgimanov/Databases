namespace CompanySampleDataImporter.Importer
{
    using System;

    class StartUp
    {
        static void Main()
        {
            // 1:09:42
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
