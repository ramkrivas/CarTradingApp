using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CarTrade.Interfaces
{
     public interface ICarTradeDataProvider<T>
    {
        Task<IEnumerable<T>> GetCarTradeData();

        Task<T> InsertRecord();

        Task<T> UpdateRecord();

        Task<T> DeleteRecord();
    }
}
