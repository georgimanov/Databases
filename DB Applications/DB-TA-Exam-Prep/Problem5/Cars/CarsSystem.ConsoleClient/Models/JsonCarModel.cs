namespace CarsSystem.ConsoleClient.Models
{
    public class JsonCarModel
    {
        public ushort Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public JsonDealerModel Dealer { get; set; }
    }
}
