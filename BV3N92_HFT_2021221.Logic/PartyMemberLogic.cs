using BV3N92_HFT_2021221.Models;
using BV3N92_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public class PartyMemberLogic : IPartyMemberLogic
    {
        IPartyMemberRepository memberRepo;

        public PartyMemberLogic(IPartyMemberRepository repo)
        {
            this.memberRepo = repo;
        }

        public void ChangeMemberAge(int memberId, int newAge)
        {
            memberRepo.ChangeMemberAge(memberId, newAge);
        }

        public void ChangeMemberAllegiance(int memberId, int newPartyId)
        {
            memberRepo.ChangeMemberAllegiance(memberId, newPartyId);
        }

        public void ChangeMemberName(int memberId, string newName)
        {
            memberRepo.ChangeMemberName(memberId, newName);
        }

        public void CreateMember(int memberId, string lastName, int age, int partyId, string partyName)
        {
            memberRepo.CreateMember(memberId, lastName, age, partyId);
        }

        public void DeleteMember(int memberId)
        {
            memberRepo.DeleteMember(memberId);
        }

        public IList<PartyMember> GetAllMembers()
        {
            return memberRepo.GetAll().ToList();
        }

        public PartyMember GetMemberByID(int id)
        {
            return memberRepo.GetOne(id);
        }
    }
}
