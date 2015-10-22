namespace CarSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        private ICollection<Car> cars;
        private ICollection<Dealer> dealers;

        public Manufacturer()
        {
            this.cars = new HashSet<Car>();
            this.dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public virtual ICollection<Dealer> Dealers
        {
            get { return this.dealers; }
            set { this.dealers = value; }
        }
    }
}
