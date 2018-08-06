using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Demo.CarTrade.Interfaces;
using Demo.CarTrade.Entity;

namespace Demo.CarTrade.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBrandManagementService" in both code and config file together.
    [ServiceContract]
    public interface IBrandManagementService
    {
        [OperationContract]
        Task<IEnumerable<Brand>> GetAll();

        [OperationContract]
        Task<Brand> GetByID(int brandId);

        [OperationContract]
        Task<Brand> Add(Brand obj);

        [OperationContract]
        Task<Brand> Update(Brand obj);
            
        [OperationContract]
        void Delete(int brandId);
    }
}
