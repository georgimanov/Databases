namespace Import_Mountains
{
    public class MountainsDto
    {
        public MountainsDto()
        {
            this.Peaks = new PeakDto[0];
            this.Countries = new string[0];
        }

        public string MountainName { get; set; }

        public PeakDto[] Peaks { get; set; }
        
        public string[] Countries { get; set; }
    }
}
