using BV3N92_HFT_2021221.Models;
using BV3N92_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public class ParliamentLogic : IParliamentLogic
    {
        IParliamentRepository parliamentRepo;
        IPartyRepository partyRepo;

        public ParliamentLogic(IParliamentRepository repo, IPartyRepository prepo)
        {
            this.parliamentRepo = repo;
            this.partyRepo = prepo;
        }

        public void ChangeName(int parliamentId, string newName)
        {
            if (parliamentId < 0)
            {
                throw new Exception("Invalid ID!");
            }
            else if (newName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }

            if (GetAllParliaments().Any(x => x.ParliamentName == newName))
            {
                throw new Exception($"A parliament with the name '{newName}' already exists!");
            }
            else if (GetAllParliaments().Any(x => x.ParliamentID == parliamentId))
            {
                parliamentRepo.ChangeName(parliamentId, newName);
            }
            else
                throw new Exception($"No such parliament with ID '{parliamentId}'!");
        }

        public void CreateParliament(int parliamentId, string name, string rulingParty)
        {
            foreach (var item in GetAllParliaments())
            {
                if (item.ParliamentName.Equals(name))
                {
                    throw new Exception($"A parliament with the name '{name}' already exists!");
                }
                else if (item.ParliamentID.Equals(parliamentId))
                {
                    throw new Exception($"A parliament with ID '{parliamentId}' already exists!");
                }
            }

            if (parliamentId < 0)
            {
                throw new Exception("Invalid ID!");
            }
            else if (name.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else if (rulingParty.Equals(string.Empty))
            {
                throw new Exception("Ruling party has to be given!");
            }
            else
                parliamentRepo.CreateParliament(parliamentId, name, rulingParty);
        }

        public void DeleteParliament(int parliamentId)
        {
            int i = 0;
            foreach (var item in GetAllParliaments())
            {
                if (item.ParliamentID.Equals(parliamentId))
                {
                    i++;
                }
            }
            //findfirst
            if (parliamentId < 0)
            {
                throw new Exception("Invalid ID!");
            }
            else if (i == 0)
            {
                throw new Exception($"No such parliament with ID '{parliamentId}'!");
            }
            else
                parliamentRepo.DeleteParliament(parliamentId);
        }

        public IList<Parliament> GetAllParliaments()
        {
            return parliamentRepo.GetAll().ToList();
        }

        public IEnumerable<Party> GetAllRulingParties()
        {

            var q = from party in partyRepo.GetAll().ToList()
                    where GetAllParliaments().ToList().FirstOrDefault(parliament => parliament.RulingParty == party.PartyName) != null
                    select party;

            return q;
        }

        public Parliament GetParliamentByID(int id)
        {
            int i = 0;
            foreach (var item in GetAllParliaments())
            {
                if (item.ParliamentID.Equals(id))
                {
                    i++;
                }
            }
            if (id < 0)
            {
                throw new Exception("Invalid ID!");
            }
            else if (i == 0)
            {
                throw new Exception($"No such parliament with ID '{id}'");
            }
            else
                return parliamentRepo.GetOne(id);
        }

        public void ReplaceRulingParty(int parliamentId, string newParty)
        {
            if (GetParliamentByID(parliamentId).RulingParty.Equals(newParty))
            {
                throw new Exception("New ruling party cannot have the same name as the old one!");
            }
            else if (newParty.Equals(string.Empty))
            {
                throw new Exception("New name has to be given!");
            }
            else
                parliamentRepo.ReplaceRulingParty(parliamentId, newParty);
        }

        public void AddNewParliament(Parliament parliament)
        {
            foreach (var item in GetAllParliaments())
            {
                if (item.ParliamentName.Equals(parliament.ParliamentName))
                {
                    throw new Exception($"A parliament with the name '{parliament.ParliamentName}' already exists!");
                }
            }

            if (parliament.ParliamentName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else if (parliament.RulingParty.Equals(string.Empty))
            {
                throw new Exception("Ruling party has to be given!");
            }
            else
                parliamentRepo.AddNewParliament(parliament);
        }

        public void UpdateParliament(Parliament parliament)
        {
            if (parliament.ParliamentID < 0)
            {
                throw new Exception("Invalid ID!");
            }
            else if (parliament.ParliamentName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else if (parliament.RulingParty.Equals(string.Empty))
            {
                throw new Exception("New name has to be given!");
            }
            else if (GetAllParliaments().Any(x => x.ParliamentName == parliament.ParliamentName))
            {
                throw new Exception($"A parliament with the name '{parliament.ParliamentName}' already exists!");
            }
            else if (GetParliamentByID(parliament.ParliamentID).RulingParty.Equals(parliament.RulingParty))
            {
                throw new Exception("New ruling party cannot have the same name as the old one!");
            }
            else if (GetAllParliaments().Any(x => x.ParliamentID == parliament.ParliamentID))
            {
                parliamentRepo.UpdateParliament(parliament);
            }
            else
                throw new Exception($"No such parliament with ID '{parliament.ParliamentID}'!");
        }
    }
}
