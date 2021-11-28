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
    public class PartyController : ControllerBase
    {
        IPartyLogic partyLogic;

        public PartyController(IPartyLogic partyLogic)
        {
            this.partyLogic = partyLogic;
        }

        // GET: /party
        [HttpGet]
        public IEnumerable<Party> Get()
        {
            return partyLogic.GetAllParties();
        }

        // GET /party/2
        [HttpGet("{id}")]
        public Party Get(int id)
        {
            return partyLogic.GetPartyByID(id);
        }

        // POST /party
        [HttpPost]
        public void Post([FromBody] Party value)
        {
            partyLogic.AddNewParty(value);
        }

        // PUT /party
        [HttpPut]
        public void Put([FromBody] Party value)
        {
            partyLogic.UpdateParty(value);
        }

        // DELETE /party/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            partyLogic.DeleteParty(id);
        }
    }
}
