using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebServer.Models;

namespace sysServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("text/json")]
    public class RocketsController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var rockets = FakeData.Rockets.ToArray();
            string jsonRockets = JsonConvert.SerializeObject(rockets);

            return jsonRockets;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var rocket = FakeData.Rockets.Where(r => r.ID == id).FirstOrDefault();
            string jsonRocket = JsonConvert.SerializeObject(rocket);

            return jsonRocket;
        }

        // POST api/values
        [HttpPost]
        public BadRequestObjectResult Post([FromBody]string value)
        {
            return BadRequest(new AccessViolationException());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public BadRequestObjectResult Put(int id, [FromBody]string value)
        {
            return BadRequest(new AccessViolationException());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public BadRequestObjectResult Delete(int id)
        {
            return BadRequest(new AccessViolationException());
        }
    }
}
