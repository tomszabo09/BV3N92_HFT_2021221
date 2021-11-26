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
        public void Post(int memberId, string lastName, int age, int partyId)
        {
            memberLogic.CreateMember(memberId, lastName, age, partyId);
        }

        // PUT /partymember
        [HttpPut]
        public void PutName(int id, string newName)
        {
            memberLogic.ChangeMemberName(id, newName);
        }

        // PUT /partymember
        [HttpPut]
        public void PutAge(int id, int newAge)
        {
            memberLogic.ChangeMemberAge(id, newAge);
        }

        // PUT /partymember
        [HttpPut]
        public void PutAllegiance(int id, int newPartyId)
        {
            memberLogic.ChangeMemberAllegiance(id, newPartyId);
        }

        // DELETE /partymember/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            memberLogic.DeleteMember(id);
        }
    }
}
