using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                    where rc.ReturnDate < fromDate
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

        public bool UpdateCarAvailability(int rentalCarId, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        /*       public List<RentalCarModel> UpdateCarAvailability(int ManufacturerId, DateTime fromDate, DateTime toDate)
               {
                   var carsToUpdate = _dataContext.RentalCar
                       .Where(rc => rc.Car.Model.ManufacturerId == ManufacturerId && rc.ReturnDate < fromDate)
                       .ToList();

                   foreach (var carToUpdate in carsToUpdate)
                   {
                       // Check if the new availability dates overlap with existing rentals
                       bool isOverlap = _dataContext.RentalCar.Any(car =>
                           car.Car.Id != carToUpdate.Car.Id &&
                           !(toDate <= car.ReturnDate || fromDate >= car.ReturnDate));

                       if (!isOverlap)
                       {
                           // Update the availability dates of the car
                           carToUpdate.BookedDate = fromDate;
                           carToUpdate.ReturnDate = toDate;
                       }
                       else
                       {
                           // There's an overlap with existing rentals, skip this car
                           continue;
                       }
                   }

                   // Save changes to the database
                   _dataContext.SaveChanges();

                   // Convert the updated RentalCar entities to RentalCarModel and return the list
                   var updatedCarModels = carsToUpdate.Select(rc => new RentalCarModel
                   {
                       Id = rc.Id,
                       BookedDate = rc.BookedDate,
                       ReturnDate = rc.ReturnDate,
                       Insurance = rc.insurance,
                       Location = rc.Location,
                       Manufacturuer = rc.Car.Model.Manufacturer.Make,
                       Model = rc.Car.Model.Model
                   }).ToList();

                   return updatedCarModels;
               }*/



        /*public bool UpdateCarAvailability(int rentalCarId, DateTime fromDate, DateTime toDate)
        {
            var carToUpdate = _dataContext.RentalCar.FirstOrDefault(rc => rc.Id == rentalCarId);

            if (carToUpdate != null)
            {
                bool isOverlap = _dataContext.RentalCar.Any(car =>
                    car.Id != rentalCarId &&
                    !(toDate <= car.ReturnDate || fromDate >= car.ReturnDate));

                if (!isOverlap)
                {
                    carToUpdate.BookedDate = fromDate;
                    carToUpdate.ReturnDate = toDate;

                    _dataContext.SaveChanges();
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
*/



        /* public bool UpdateCarAvailability(string Make, DateTime fromDate, DateTime toDate)
         {
             var carsToUpdate = from rc in _dataContext.RentalCar
                                join cm in _dataContext.CarModel on rc.CarId equals cm.Id
                                join man in _dataContext.Manufacturer on cm.ManufacturerId equals man.Id
                                where rc.ReturnDate < fromDate
                                select new RentalCarModel()
                                {
                                    Id = rc.Id,
                                    BookedDate = rc.BookedDate,
                                    ReturnDate = rc.ReturnDate,
                                    Insurance = rc.insurance,
                                    Location = rc.Location,
                                    Manufacturuer = man.Make,
                                    Model = cm.Model
                                };


             foreach (var carToUpdate in carsToUpdate)
             {
                 // Check if the new availability dates overlap with existing rentals
                 bool isOverlap = _dataContext.RentalCar.Any(car =>
                     car.CarId != carToUpdate.Id &&
                     !(toDate <= car.ReturnDate || fromDate >= car.ReturnDate));

                 if (!isOverlap)
                 {
                     // Update the availability dates of the car
                     carToUpdate.BookedDate = fromDate;
                     carToUpdate.ReturnDate = toDate;
                 }
                 else
                 {
                     // There's an overlap with existing rentals, skip this car
                     continue;
                 }
             }
             _dataContext.SaveChanges();
             return carsToUpdate;

             }*/



    }
}
