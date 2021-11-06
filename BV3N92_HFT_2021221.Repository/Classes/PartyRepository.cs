﻿using BV3N92_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Repository
{
    public class PartyRepository : Repository<Party>, IPartyRepository
    {
        public PartyRepository(DbContext ctx) : base(ctx)
        {

        }

        public void ChangeIdeology(int partyId, Ideologies newIdeology)
        {
            var party = GetOne(partyId);
            party.Ideology = newIdeology;
            ctx.SaveChanges();
        }

        public void ChangePartyName(int partyId, string newName)
        {
            var party = GetOne(partyId);
            party.PartyName = newName;
            ctx.SaveChanges();
        }

        public override Party GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.PartyID.Equals(id));
        }
    }
}
