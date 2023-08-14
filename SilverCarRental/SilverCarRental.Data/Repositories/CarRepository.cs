using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Data.Repositories
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(SilverDataContext context) : base(context)
        {

        }
        
    }
}
