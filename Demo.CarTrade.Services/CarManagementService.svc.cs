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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarManagementService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CarManagementService.svc or CarManagementService.svc.cs at the Solution Explorer and start debugging.
    public class CarManagementService : ICarManagementService
    {
        private readonly IRepository<Car> _carManagementRepository;
        public CarManagementService(IRepository<Car> carManagementRepositoty)
        {
            _carManagementRepository = carManagementRepositoty;
        }
        public CarManagementService()
        {

        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            var response = await _carManagementRepository.GetAll();
            return response;
        }
        public async Task<Car> GetByID(int brandId)
        {
            var response = await _carManagementRepository.GetById(brandId);
            return response;
        }
        public async Task<Car> Add(Car value)
        {
            var response = _carManagementRepository.Add(value);
            return response;
        }

        public async Task<Car> Update(Car value)
        {
            var response = _carManagementRepository.Update(value);
            return response;
        }
        public void Delete(int brandId)
        {
            _carManagementRepository.Delete(brandId);
        }
    }
}
