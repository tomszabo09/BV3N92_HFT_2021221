using BV3N92_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public interface IPartyMemberLogic
    {
        PartyMember GetMemberByID(int id);

        void CreateMember(int memberId, string lastName, int age, int partyId, string partyName);

        void ChangeMemberName(int memberId, string newName);

        void ChangeMemberAge(int memberId, int newAge);

        void ChangeMemberAllegiance(int memberId, int newPartyId);

        void DeleteMember(int memberId);

        IList<PartyMember> GetAllMembers();
    }
}
