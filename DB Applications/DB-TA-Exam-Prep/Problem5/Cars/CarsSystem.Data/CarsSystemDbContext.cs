namespace CarsSystem.Data
{
    using System.Data.Entity;

    using CarSystem.Models;

    public class CarsSystemDbContext : DbContext
    {
        public CarsSystemDbContext()
            : base("CarsSystem")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<Dealer> Dealers { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
    }
}
