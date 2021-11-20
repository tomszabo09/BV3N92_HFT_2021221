using BV3N92_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public interface IPartyLogic
    {
        Party GetPartyByID(int id);

        void CreateParty(int partyId, int parliamentId, string partyName, Ideologies ideology);

        void ChangePartyName(int partyId, string newName);

        void ChangeIdeology(int partyId, Ideologies newIdeology);

        void DeleteParty(int partyId);

        IEnumerable<PartyMember> GetShortNamedMembers(int partyId, int maxNameLength);

        IEnumerable<PartyMember> GetSeniorMembers(int partyId);

        IEnumerable<PartyMember> GetJuniorMembers(int partyId);

        IEnumerable<PartyMember> GetSameIdeologyMembers(Ideologies ideology);

        IList<Party> GetAllParties();
    }
}
