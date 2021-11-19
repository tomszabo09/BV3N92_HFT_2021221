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

        void GetPartysParliament(int partyId);

        IList<Party> GetAllParties();

        IList<PartyMember> GetAllMembersOfParty();
    }
}
