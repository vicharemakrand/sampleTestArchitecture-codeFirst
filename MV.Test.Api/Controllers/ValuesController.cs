using MV.Prometric.EntityModels;
using MV.Prometric.IDomainServices;
using MV.Prometric.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MV.Test.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IVehicleService service;

        public ValuesController(IVehicleService service)
        {
            this.service = service;
        }
        // GET api/values
        public List<VehicleViewModel> Get()
        {
            var vehicles = service.GetAll();
            return vehicles;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
