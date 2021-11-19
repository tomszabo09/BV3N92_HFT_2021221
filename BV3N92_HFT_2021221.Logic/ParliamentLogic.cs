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

        public ParliamentLogic(IParliamentRepository repo)
        {
            this.parliamentRepo = repo;
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

            foreach (var item in GetAllParliaments())
            {
                if (item.ParliamentName.Equals(newName))
                {
                    throw new Exception($"A parliament with the name '{newName}' already exists!");
                }
                else if (item.ParliamentID.Equals(parliamentId))
                {
                    parliamentRepo.ChangeName(parliamentId, newName);
                }
                else
                    throw new Exception($"No such parliament with ID '{parliamentId}'!");
            }
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
            if (GetParliamentByID(parliamentId).Ruling_Party.Equals(newParty))
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
