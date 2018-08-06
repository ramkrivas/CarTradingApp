using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CarTrade.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object Id);
        T Add(T obj);
        void Delete(object Id);
        T Update(T obj);
        void Save();
    }
}
