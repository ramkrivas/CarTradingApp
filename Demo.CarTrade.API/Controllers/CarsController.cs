using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.CarTrade.Interfaces;
using Newtonsoft.Json;
using Demo.CarTrade.Entity;
using System.Threading.Tasks;
namespace Demo.CarTrade.API.Controllers
{
    public class CarsController : ApiController
    {
        private readonly ICarManagementService _carManagementService;
        public CarsController(ICarManagementService carManagementService)
        {
            _carManagementService = carManagementService;
        }
        [HttpGet]
        // GET: api/Cars
        public async Task<HttpResponseMessage> Get()

        {
            var output = await _carManagementService.GetAll();
            var response = JsonConvert.SerializeObject(output);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<List<Car>>(response));

        }
        [HttpGet]
        // GET: api/Cars/101
        public async Task<HttpResponseMessage> Get(int id)
        {
            var output = await _carManagementService.GetByID(id);
            var response = JsonConvert.SerializeObject(output);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<Car>(response));
        }

        [HttpPost]
        // POST: api/Cars
        public async Task<HttpResponseMessage> Post([FromBody]Car value)
        {
            var output = await _carManagementService.Add(value);
            var response = JsonConvert.SerializeObject(output);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<Car>(response));
        }
        [HttpPut]
        // PUT: api/Cars/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]Car value)
        {
            var output = await _carManagementService.Update(value);
            var response = JsonConvert.SerializeObject(output);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<Car>(response));
        }
        [HttpDelete]
        // DELETE: api/Cars/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _carManagementService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No-Content");
            }

        }
    }
}
