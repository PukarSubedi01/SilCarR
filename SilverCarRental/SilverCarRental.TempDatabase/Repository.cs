using SilverCarRental.Core.Interface;
using SilverCarRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.TempDatabase
{
    //public interface IRepository<T> where T : class
    //{
    //    IEnumerable<T> GetAll();
    //    T GetById(int id);
    //    void Insert(T obj);
    //    void Update(T obj);
    //    void Delete(int id);
    //    void Save();
    //}
    public class CarRepository<T> : IRepository<Car>
    {

       

        public IEnumerable<Car> GetAll()
        {
            return SilverCarDatabase.GetCars();
        }

        public Car GetById(int id)
        {
            var listOfCars = SilverCarDatabase.GetCars();
            var car = listOfCars.Where(x => x.Id == id).First();
            return car;
        }

        public IEnumerable<Car> GetByColor(string color)
        {
            var listOfCars = SilverCarDatabase.GetCars();
            var car = listOfCars.Where(x => x.Color.Trim().Equals(color, StringComparison.OrdinalIgnoreCase)).ToList<Car>();
            return car;
        }

        public void Insert(Car car)
        {
            SilverCarDatabase.AddCar(car);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(int id,Car car)
        {
            SilverCarDatabase.UpdateCar(id,car);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }


}
