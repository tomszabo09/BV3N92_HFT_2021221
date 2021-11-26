using BV3N92_HFT_2021221.Logic;
using BV3N92_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IParliamentLogic parliamentLogic;
        IPartyLogic partyLogic;

        public StatController(IParliamentLogic parliamentLogic, IPartyLogic partyLogic)
        {
            this.parliamentLogic = parliamentLogic;
            this.partyLogic = partyLogic;
        }

        // GET: stat/getallrulingparties
        [HttpGet]
        public IEnumerable<Party> GetAllRulingParties()
        {
            return parliamentLogic.GetAllRulingParties();
        }

        // GET: stat/getshortnamedmembers
        [HttpGet]
        public IEnumerable<PartyMember> GetShortNamedMembers(int partyId, int maxNameLength)
        {
            return partyLogic.GetShortNamedMembers(partyId, maxNameLength);
        }

        // GET: stat/getseniormembers
        [HttpGet]
        public IEnumerable<PartyMember> GetSeniorMembers(int partyId)
        {
            return partyLogic.GetSeniorMembers(partyId);
        }

        // GET: stat/getjuniormembers
        [HttpGet]
        public IEnumerable<PartyMember> GetJuniorMembers(int partyId)
        {
            return partyLogic.GetJuniorMembers(partyId);
        }

        // GET: stat/getsameideologymembers
        [HttpGet]
        public IEnumerable<PartyMember> GetSameIdeologyMembers(string ideology)
        {
            return partyLogic.GetSameIdeologyMembers(ideology);
        }
    }
}
