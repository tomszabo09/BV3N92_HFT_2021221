using BV3N92_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Repository
{
    public class ParliamentRepository : Repository<Parliament>, IParliamentRepository
    {
        public ParliamentRepository(DbContext ctx) : base(ctx)
        {

        }

        public void ChangeName(int parliamentId, string newName)
        {
            var parliament = GetOne(parliamentId);
            parliament.ParliamentName = newName;
            ctx.SaveChanges();
        }

        public void ReplaceRulingParty(int parliamentId, string newParty)
        {
            var parliament = GetOne(parliamentId);
            parliament.Ruling_Party = newParty;
            ctx.SaveChanges();
        }

        public override Parliament GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ParliamentID.Equals(id));
        }
    }
}
