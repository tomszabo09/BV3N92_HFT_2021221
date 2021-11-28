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
    public class PartyMemberController : ControllerBase
    {
        IPartyMemberLogic memberLogic;

        public PartyMemberController(IPartyMemberLogic memberLogic)
        {
            this.memberLogic = memberLogic;
        }

        // GET: /partymember
        [HttpGet]
        public IEnumerable<PartyMember> Get()
        {
            return memberLogic.GetAllMembers();
        }

        // GET /partymember/2
        [HttpGet("{id}")]
        public PartyMember Get(int id)
        {
            return memberLogic.GetMemberByID(id);
        }

        // POST /partymember
        [HttpPost]
        public void Post([FromBody] PartyMember value)
        {
            memberLogic.AddNewMember(value);
        }

        // PUT /partymember
        [HttpPut]
        public void Put([FromBody] PartyMember value)
        {
            memberLogic.UpdateMember(value);
        }

        // DELETE /partymember/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            memberLogic.DeleteMember(id);
        }
    }
}
