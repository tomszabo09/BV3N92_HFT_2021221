using BV3N92_HFT_2021221.Endpoint.Services;
using BV3N92_HFT_2021221.Logic;
using BV3N92_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IPartyMemberLogic memberLogic;
        IHubContext<SignalRHub> hub;

        public PartyController(IPartyLogic partyLogic, IPartyMemberLogic memberLogic, IHubContext<SignalRHub> hub)
        {
            this.partyLogic = partyLogic;
            this.memberLogic = memberLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("PartyCreated", value);
        }

        // PUT /party
        [HttpPut]
        public void Put([FromBody] Party value)
        {
            partyLogic.UpdateParty(value);
            hub.Clients.All.SendAsync("PartyUpdated", value);
        }

        // DELETE /party/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDel = partyLogic.GetPartyByID(id);

            foreach (var member in memberLogic.GetAllMembers())
            {
                if (member.PartyID == toDel.PartyID)
                {
                    hub.Clients.All.SendAsync("PartyMemberDeleted", member);
                }

            }
            
            partyLogic.DeleteParty(id);
            hub.Clients.All.SendAsync("PartyDeleted", toDel);
        }
    }
}
