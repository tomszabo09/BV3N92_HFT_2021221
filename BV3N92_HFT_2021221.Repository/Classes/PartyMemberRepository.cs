﻿using BV3N92_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Repository
{
    public class PartyMemberRepository : Repository<PartyMember>, IPartyMemberRepository
    {
        public PartyMemberRepository(DbContext ctx) : base(ctx)
        {

        }

        public void ChangeMemberAge(int memberId, int newAge)
        {
            var member = GetOne(memberId);
            member.Age = newAge;
            ctx.SaveChanges();
        }

        public void ChangeMemberAllegiance(int memberId, int newPartyId)
        {
            var member = GetOne(memberId);
            member.PartyID = newPartyId;
            ctx.SaveChanges();
        }

        public void ChangeMemberName(int memberId, string newName)
        {
            var member = GetOne(memberId);
            member.LastName = newName;
            ctx.SaveChanges();
        }

        public override PartyMember GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.MemberID.Equals(id));
        }
    }
}
