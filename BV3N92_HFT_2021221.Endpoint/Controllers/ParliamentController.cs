using BV3N92_HFT_2021221.Logic;
using BV3N92_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BV3N92_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParliamentController : ControllerBase
    {
        IParliamentLogic pl;

        public ParliamentController(IParliamentLogic pl)
        {
            this.pl = pl;
        }

        // GET: /parliament
        [HttpGet]
        public IEnumerable<Parliament> Get()
        {
            return pl.GetAllParliaments();
        }

        // GET /parliament/2
        [HttpGet("{id}")]
        public Parliament Get(int id)
        {
            return pl.GetParliamentByID(id);
        }

        // POST /parliament
        [HttpPost]
        public void Post([FromBody] Parliament value)
        {
        }

        // PUT /parliament
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE /parliament/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
