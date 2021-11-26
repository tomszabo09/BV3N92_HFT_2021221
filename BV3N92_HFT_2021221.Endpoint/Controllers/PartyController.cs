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
        public void Post(int partyId, int parliamentId, string partyName, string ideology)
        {
            partyLogic.CreateParty(partyId, parliamentId, partyName, ideology);
        }

        // PUT /party
        [HttpPut]
        public void PutName(int id, string newName)
        {
            partyLogic.ChangePartyName(id, newName);
        }

        // PUT /party
        [HttpPut]
        public void PutIdeology(int id, string newIdeology)
        {
            partyLogic.ChangeIdeology(id, newIdeology);
        }

        // DELETE /party/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            partyLogic.DeleteParty(id);
        }
    }
}
