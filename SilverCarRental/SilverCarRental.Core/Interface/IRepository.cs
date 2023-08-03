using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCarRental.Core.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FetchAll();
        T GetById(int id);
        IEnumerable<T> GetByColor(string id);
        void Insert(T obj);
        void Update(int id,T obj);
        void Delete(int id);
        void Save();
    }
}
