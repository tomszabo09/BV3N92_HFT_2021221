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
            if (partyId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (GetPartyByID(partyId).Ideology.Equals(newIdeology))
            {
                throw new Exception("New ideology cannot match old one!");
            }
            else
                partyRepo.ChangeIdeology(partyId, newIdeology);
        }

        public void ChangePartyName(int partyId, string newName)
        {
            if (partyId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (newName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else if (GetPartyByID(partyId).PartyName.Equals(newName))
            {
                throw new Exception("New name cannot match old one!");
            }
            else
                partyRepo.ChangePartyName(partyId, newName);
        }

        public void CreateParty(int partyId, int parliamentId, string partyName, Ideologies ideology)
        {
            foreach (var item in GetAllParties())
            {
                if (item.PartyName.Equals(partyName))
                {
                    throw new Exception($"A party with the name '{partyName}' already exists!");
                }
                else if (item.PartyID.Equals(partyId))
                {
                    throw new Exception($"A party with ID '{partyId}' already exists!");
                }
            }

            if (partyId.Equals(null))
            {
                throw new Exception("Party ID has to be given!");
            }
            else if (parliamentId.Equals(null))
            {
                throw new Exception("Parliament ID has to be given!");
            }
            else if (partyName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else
                partyRepo.CreateParty(partyId, parliamentId, partyName, ideology);
        }

        public void DeleteParty(int partyId)
        {
            int i = 0;
            foreach (var item in GetAllParties())
            {
                if (item.PartyID.Equals(partyId))
                {
                    i++;
                }
            }

            if (partyId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (i == 0)
            {
                throw new Exception($"No such party with ID '{partyId}'!");
            }
            else
                partyRepo.DeleteParty(partyId);
        }

        public IList<Party> GetAllParties()
        {
            return partyRepo.GetAll().ToList();
        }

        public Party GetPartyByID(int id)
        {
            int i = 0;
            foreach (var item in GetAllParties())
            {
                if (item.PartyID.Equals(id))
                {
                    i++;
                }
            }
            if (id.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (i == 0)
            {
                throw new Exception($"No such party with ID '{id}'!");
            }
            else
                return partyRepo.GetOne(id);
        }
    }
}
