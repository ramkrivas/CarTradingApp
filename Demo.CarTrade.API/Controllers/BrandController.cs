using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Demo.CarTrade.Interfaces;
using Newtonsoft.Json;
using Demo.CarTrade.Entity;

namespace Demo.CarTrade.API.Controllers
{
    public class BrandController : ApiController
    {
        private readonly IBrandManagementService _brandManagementService;
        public BrandController(IBrandManagementService brandManagementService)
        {
            _brandManagementService = brandManagementService;
        }
        [HttpGet]
        // GET: api/Brand
        public async Task<HttpResponseMessage> Get()
        {
            var output=await  _brandManagementService.GetAll();
            var response = JsonConvert.SerializeObject(output);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<List<Brand>>(response));
            
        }
        [HttpGet]
        // GET: api/Brand/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var output = await _brandManagementService.GetByID(id);
            if (output == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                var response = JsonConvert.SerializeObject(output);
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<Brand>(response));
            }
            
        }

        [HttpPost]
        // POST: api/Brand
        public async Task<HttpResponseMessage> Post([FromBody]Brand value)
        {
            var output = await _brandManagementService.Add(value);
            var response = JsonConvert.SerializeObject(output);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject<Brand>(response));
        }
        [HttpPut]
        // PUT: api/Brand/5
        public void Put(int id, [FromBody]Brand value)
        {
        }
        [HttpDelete]
        // DELETE: api/Brand/5
        public HttpResponseMessage Delete(int id)
        {
            try {
                _brandManagementService.Delete(id);
                return  Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No-Content");
            }

        }
    }
}
