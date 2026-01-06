using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pc2dddcleantravelers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellerController : ControllerBase
    {
        // GET: api/Traveller
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Traveller/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Traveller
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Traveller/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Traveller/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
