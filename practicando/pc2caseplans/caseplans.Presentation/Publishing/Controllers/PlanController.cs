using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caseplans.Presentation.Publishing.Controllers
{
    [Route("api/v1/plans ")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        // POST: api/Plan
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        /*// GET: api/Plan
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Plan/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Plan/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Plan/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
