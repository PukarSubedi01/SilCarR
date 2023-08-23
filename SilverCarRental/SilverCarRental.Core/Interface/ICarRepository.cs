using SilverCarRental.Data;
using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Core.Interface
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetAvailbaleCars(
            List<Expression<Func<Car, bool>>> filters = null, 
            Func<IQueryable<Car>, IOrderedQueryable<Car>> orderBy = null, 
            string includeProperties = ""
            );
    }
}
