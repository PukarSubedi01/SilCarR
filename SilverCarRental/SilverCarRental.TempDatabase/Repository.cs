using SilverCarRental.Core.Interface;
using SilverCarRental.Data;
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
    public class CarRepository<T> : IRepository<Car>, Repos
    {

       

    }


}
