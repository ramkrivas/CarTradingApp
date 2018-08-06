using Demo.CarTrade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Demo.CarTrade.Entity;
using Demo.CarTrade.Repository;

namespace Demo.CarTrade.Services
{
    /// <summary>
    /// This Service helps in CRUD operations on different Car Brands 
    /// </summary>
    public class BrandManagementService : IBrandManagementService
    {  
        private readonly IRepository<Brand> _brandManagementRepoitory;
        public BrandManagementService(IRepository<Brand> brandManagementRepoitory)
        {
           _brandManagementRepoitory = brandManagementRepoitory;
        }
        public BrandManagementService()
        {

        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            var response = await _brandManagementRepoitory.GetAll();
            return response;
        }
        public async Task<Brand> GetByID(int brandId)
        {
            var response = await  _brandManagementRepoitory.GetById(brandId);
            return response;
        }
        public async Task<Brand> Add(Brand value)
        {
            var response =  _brandManagementRepoitory.Add(value);
            return response;
        }

        public async Task<Brand> Update(Brand value)
        {
            var response = _brandManagementRepoitory.Update(value);
            return response;
        }
        public void Delete(int brandId)
        {
             _brandManagementRepoitory.Delete(brandId);           
        }
    }
}
