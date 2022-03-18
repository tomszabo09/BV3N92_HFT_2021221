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
    public class ParliamentController : ControllerBase
    {
        IParliamentLogic parliamentLogic;
        IPartyLogic partyLogic;
        IPartyMemberLogic memberLogic;
        IHubContext<SignalRHub> hub;

        public ParliamentController(IParliamentLogic parliamentLogic, IPartyLogic partyLogic, IPartyMemberLogic memberLogic, IHubContext<SignalRHub> hub)
        {
            this.parliamentLogic = parliamentLogic;
            this.partyLogic = partyLogic;
            this.memberLogic = memberLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("ParliamentCreated", value);
        }

        // PUT /parliament
        [HttpPut]
        public void Put([FromBody] Parliament value)
        {
            parliamentLogic.UpdateParliament(value);
            hub.Clients.All.SendAsync("ParliamentUpdated", value);
        }

        // DELETE /parliament/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDel = parliamentLogic.GetParliamentByID(id);

            foreach (var party in partyLogic.GetAllParties())
            {
                if (party.ParliamentID == toDel.ParliamentID)
                {
                    foreach (var member in memberLogic.GetAllMembers())
                    {
                        if (member.PartyID == party.PartyID)
                        {
                            hub.Clients.All.SendAsync("PartyMemberDeleted", member);
                        }
                    }
                    hub.Clients.All.SendAsync("PartyDeleted", party);
                }
            }

            parliamentLogic.DeleteParliament(id);
            hub.Clients.All.SendAsync("ParliamentDeleted", toDel);
        }
    }
}
