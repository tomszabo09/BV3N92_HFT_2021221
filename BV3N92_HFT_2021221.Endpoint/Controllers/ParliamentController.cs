using BV3N92_HFT_2021221.Logic;
using BV3N92_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParliamentController : ControllerBase
    {
        IParliamentLogic parliamentLogic;

        public ParliamentController(IParliamentLogic parliamentLogic)
        {
            this.parliamentLogic = parliamentLogic;
        }

        // GET: /parliament
        [HttpGet]
        public IEnumerable<Parliament> Get()
        {
            return parliamentLogic.GetAllParliaments();
        }

        // GET /parliament/2
        [HttpGet("{id}")]
        public Parliament Get(int id)
        {
            return parliamentLogic.GetParliamentByID(id);
        }

        // POST /parliament
        [HttpPost]
        public void Post([FromBody] Parliament value)
        {
            parliamentLogic.AddNewParliament(value);
        }

        // PUT /parliament
        [HttpPut]
        public void Put([FromBody] Parliament value)
        {
            parliamentLogic.UpdateParliament(value);
        }

        // DELETE /parliament/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            parliamentLogic.DeleteParliament(id);
        }
    }
}
