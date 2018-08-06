using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Demo.CarTrade.Entity;
namespace Demo.CarTrade.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarManagementService" in both code and config file together.
    [ServiceContract]
    public interface ICarManagementService
    {
        [OperationContract]
        Task<IEnumerable<Car>> GetAll();

        [OperationContract]
        Task<Car> GetByID(int carId);

        [OperationContract]
        Task<Car> Add(Car obj);

        [OperationContract]
        Task<Car> Update(Car obj);

        [OperationContract]
        void Delete(int carId);
    }
}
