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
        public void Post(int id, string name, string rulingParty)
        {
            parliamentLogic.CreateParliament(id, name, rulingParty);
        }

        // PUT /parliament
        [HttpPut]
        public void PutName(int id, string newName)
        {
            parliamentLogic.ChangeName(id, newName);
        }

        // PUT /parliament
        [HttpPut]
        public void PutRulingParty(int id, string newParty)
        {
            parliamentLogic.ReplaceRulingParty(id, newParty);
        }

        // DELETE /parliament/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            parliamentLogic.DeleteParliament(id);
        }
    }
}
