using SilverCarRental.Core.DomainModel;
using SilverCarRental.Core.Interface;
using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        SilverDataContext _dataContext;
        public CarRepository(SilverDataContext context) : base(context)
        {
            _dataContext = context;
        }

        public IList<RentalCarModel> GetAllAvailableCars(DateTime fromDate, DateTime toDate)
        {
            return (from rc in _dataContext.RentalCar
                    join cm in _dataContext.CarModel on rc.CarId equals cm.Id
                    join man in _dataContext.Manufacturer on cm.ManufacturerId equals man.Id
                    where rc.ReturnDate >= fromDate
                    select new RentalCarModel()
                    {
                        Id = rc.Id,
                        BookedDate = rc.BookedDate,
                        ReturnDate = rc.ReturnDate,
                        Insurance = rc.insurance,
                        Location = rc.Location,
                        Manufacturuer = man.Make,
                        Model = cm.Model
                    }
                                  ).ToList();
        }

    }
}
