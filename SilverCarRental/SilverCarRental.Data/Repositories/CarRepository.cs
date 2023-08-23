using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SilverCarRental.Core.Interface;
using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SilverCarRental.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly SilverDataContext context;

        public CarRepository(SilverDataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Car>> GetAvailbaleCars(List<Expression<Func<Car, bool>>> filters = null, Func<IQueryable<Car>, IOrderedQueryable<Car>> orderBy = null, string includeProperties = "")
        {
            var query = (from car in context.Car
                               join rc in context.RentalCar on car.Id equals rc.CarId into carRentals
                               from rental in carRentals.DefaultIfEmpty()
                               where rental == null || rental.ReturnDate < DateTime.Now
                               select car
                 );

            if (!filters.IsNullOrEmpty())
            {
                foreach(var filter in filters)
                {
                    query = query.Where(filter);
                }
               
            }
            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}
