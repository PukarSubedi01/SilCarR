using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Data.Repositories
{
    internal class ManufacturerRepository : Repository<Manufacturer>, IRepository<Manufacturer>
    {
        public ManufacturerRepository(SilverDataContext context) : base(context)
        {
        }
    }
}
