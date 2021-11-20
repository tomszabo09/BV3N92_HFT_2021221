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
            if (parliamentId.Equals(null))
            {
                throw new Exception("ID has to be given!");
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

            if (parliamentId.Equals(null))
            {
                throw new Exception("ID has to be given!");
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
            if (parliamentId.Equals(null))
            {
                throw new Exception("ID has to be given!");
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
            if (id.Equals(null))
            {
                throw new Exception("ID has to be given!");
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
    }
}
