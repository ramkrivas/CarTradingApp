using Demo.CarTrade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.CarTrade.Entity;
namespace Demo.CarTrade.Services.Client
{
    public class BrandManagementServiceClient : CarTradeServiceClient<IBrandManagementService>, IBrandManagementService
    {
        public BrandManagementServiceClient(string configurationName) : base(configurationName)
        {

        }
        public BrandManagementServiceClient()
        {

        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await Channel.GetAll();
        }

        public async Task<Brand> GetByID(int brandId)
        {
            return await Channel.GetByID(brandId);
        }
        public async Task<Brand> Add(Brand obj)
        {
            return await Channel.Add(obj);
        }

        public async Task<Brand> Update(Brand obj)
        {
            return await Channel.Update(obj);
        }

        public async void Delete(int id)
        {
             Channel.Delete(id);
        }

       
        
    }
}
