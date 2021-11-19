using BV3N92_HFT_2021221.Models;
using BV3N92_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public class PartyLogic : IPartyLogic
    {
        IPartyRepository partyRepo;

        public PartyLogic(IPartyRepository repo)
        {
            this.partyRepo = repo;
        }

        public void ChangeIdeology(int partyId, Ideologies newIdeology)
        {
            partyRepo.ChangeIdeology(partyId, newIdeology);
        }

        public void ChangePartyName(int partyId, string newName)
        {
            partyRepo.ChangePartyName(partyId, newName);
        }

        public void CreateParty(int partyId, int parliamentId, string partyName, Ideologies ideology)
        {
            partyRepo.CreateParty(partyId, parliamentId, partyName, ideology);
        }

        public void DeleteParty(int partyId)
        {
            partyRepo.DeleteParty(partyId);
        }

        public IList<Party> GetAllParties()
        {
            return partyRepo.GetAll().ToList();
        }

        public Party GetPartyByID(int id)
        {
            return partyRepo.GetOne(id);
        }
    }
}
