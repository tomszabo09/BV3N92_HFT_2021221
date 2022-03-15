﻿using BV3N92_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public interface IParliamentLogic
    {
        Parliament GetParliamentByID(int id);

        void CreateParliament(int parliamentId, string name, string rulingParty);

        void ChangeName(int parliamentId, string newName);

        void ReplaceRulingParty(int parliamentId, string newParty);

        void DeleteParliament(int parliamentId);

        IEnumerable<KeyValuePair<string, int>> RepresentativesPerParliament();

        IQueryable<Parliament> GetAllParliaments();

        void AddNewParliament(Parliament parliament);

        void UpdateParliament(Parliament parliament);
    }
}
