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

        // GET: stat/getshortnamedmembers/2
        [HttpGet("{partyId}")]
        public IEnumerable<PartyMember> GetShortNamedMembers(int partyId)
        {
            return partyLogic.GetShortNamedMembers(partyId);
        }

        // GET: stat/getseniormembers/2
        [HttpGet("{partyId}")]
        public IEnumerable<PartyMember> GetSeniorMembers(int partyId)
        {
            return partyLogic.GetSeniorMembers(partyId);
        }

        // GET: stat/getjuniormembers/2
        [HttpGet("{partyId}")]
        public IEnumerable<PartyMember> GetJuniorMembers(int partyId)
        {
            return partyLogic.GetJuniorMembers(partyId);
        }

        // GET: stat/getsameideologymembers/ideology
        [HttpGet("{ideology}")]
        public IEnumerable<PartyMember> GetSameIdeologyMembers(string ideology)
        {
            return partyLogic.GetSameIdeologyMembers(ideology);
        }
    }
}
