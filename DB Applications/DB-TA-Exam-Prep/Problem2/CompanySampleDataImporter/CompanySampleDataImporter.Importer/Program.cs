namespace CompanySampleDataImporter.Importer
{
    using System;

    class StartUp
    {
        static void Main()
        {
            // 2:01:52
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
