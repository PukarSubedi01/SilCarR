using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Data.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(SilverDataContext context) : base(context)
        {
        }
    }
}
