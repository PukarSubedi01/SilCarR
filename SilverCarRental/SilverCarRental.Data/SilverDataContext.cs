using Microsoft.EntityFrameworkCore;
using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Data
{
    public class SilverDataContext: DbContext
    {
        public SilverDataContext(DbContextOptions<SilverDataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public  DbSet<Car> Car { get; set; }
        public  DbSet<Manufacturer> Manufacturer { get; set; }
        public  DbSet<CarModel> CarModel { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RentalCar> RentalCar { get; set; }


    }
}
