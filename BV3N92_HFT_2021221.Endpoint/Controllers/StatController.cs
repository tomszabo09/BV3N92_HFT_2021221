using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BV3N92_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
