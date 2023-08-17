using SilverCarRental.Core.DomainModel;
using SilverCarRental.Data;
using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Core.Interface
{
    public interface ICarRepository : IRepository<Car>
    {
        IList<RentalCarModel> GetAllAvailableCars(DateTime fromDate, DateTime toDate);
    }
}