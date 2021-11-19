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
            parliamentRepo.ChangeName(parliamentId, newName);
        }

        public void CreateParliament(int parliamentId, string name, string rulingParty)
        {
            parliamentRepo.CreateParliament(parliamentId, name, rulingParty);
        }

        public void DeleteParliament(int parliamentId)
        {
            parliamentRepo.DeleteParliament(parliamentId);
        }

        public IList<Parliament> GetAllParliaments()
        {
            return parliamentRepo.GetAll().ToList();
        }

        public Parliament GetParliamentByID(int id)
        {
            return parliamentRepo.GetOne(id);
        }

        public void ReplaceRulingParty(int parliamentId, string newParty)
        {
            parliamentRepo.ReplaceRulingParty(parliamentId, newParty);
        }
    }
}
