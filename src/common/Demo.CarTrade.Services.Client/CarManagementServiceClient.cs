using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.CarTrade.Entity;
using Demo.CarTrade.Interfaces;
namespace Demo.CarTrade.Services.Client
{
    public class CarManagementServiceClient : CarTradeServiceClient<ICarManagementService>, ICarManagementService
    {
        public CarManagementServiceClient(string configurationName) : base(configurationName)
        {

        }
        public CarManagementServiceClient()
        {

        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            return await Channel.GetAll();
        }

        public async Task<Car> GetByID(int brandId)
        {
            return await Channel.GetByID(brandId);
        }
        public async Task<Car> Add(Car obj)
        {
            return await Channel.Add(obj);
        }

        public async Task<Car> Update(Car obj)
        {
            return await Channel.Update(obj);
        }

        public async void Delete(int id)
        {
            Channel.Delete(id);
        }

    }
}
