using BV3N92_HFT_2021221.Models;
using BV3N92_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Logic
{
    public class PartyMemberLogic : IPartyMemberLogic
    {
        IPartyMemberRepository memberRepo;

        public PartyMemberLogic(IPartyMemberRepository repo)
        {
            this.memberRepo = repo;
        }

        public void ChangeMemberAge(int memberId, int newAge)
        {
            if (memberId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (GetMemberByID(memberId).Age.Equals(newAge))
            {
                throw new Exception("New age cannot be old one!");
            }
            else if (GetMemberByID(memberId).Age < 18 || GetMemberByID(memberId).Age > 70)
            {
                throw new Exception("The age pool is between 18 and 70 years!");
            }
            else
                memberRepo.ChangeMemberAge(memberId, newAge);
        }

        public void ChangeMemberAllegiance(int memberId, int newPartyId)
        {
            if (memberId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (GetMemberByID(memberId).PartyID.Equals(newPartyId))
            {
                throw new Exception("New party ID matches old one!");
            }
            else
                memberRepo.ChangeMemberAllegiance(memberId, newPartyId);
        }

        public void ChangeMemberName(int memberId, string newName)
        {
            if (memberId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (GetMemberByID(memberId).LastName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else if (GetMemberByID(memberId).LastName.Equals(newName))
            {
                throw new Exception("New name matches old one!");
            }
            else
                memberRepo.ChangeMemberName(memberId, newName);
        }

        public void CreateMember(int memberId, string lastName, int age, int partyId)
        {
            foreach (var item in GetAllMembers())
            {
                if (item.MemberID.Equals(memberId))
                {
                    throw new Exception($"A member with the ID '{memberId}' already exists!");
                }
            }

            if (memberId.Equals(null))
            {
                throw new Exception("Member ID has to be given!");
            }
            else if (lastName.Equals(string.Empty))
            {
                throw new Exception("Name has to be given!");
            }
            else if (age.Equals(null))
            {
                throw new Exception("Age has to be given!");
            }
            else if (age < 18 || age > 70)
            {
                throw new Exception("The age pool is between 18 and 70 years!");
            }
            else if (partyId.Equals(null))
            {
                throw new Exception("Party ID has to be given!");
            }
            else
                memberRepo.CreateMember(memberId, lastName, age, partyId);
        }

        public void DeleteMember(int memberId)
        {
            int i = 0;
            foreach (var item in GetAllMembers())
            {
                if (item.MemberID.Equals(memberId))
                {
                    i++;
                }
            }

            if (memberId.Equals(null))
            {
                throw new Exception("ID has to be given!");
            }
            else if (i == 0)
            {
                throw new Exception($"No such party member with ID '{memberId}'!");
            }
            else
                memberRepo.DeleteMember(memberId);
        }

        public IList<PartyMember> GetAllMembers()
        {
            return memberRepo.GetAll().ToList();
        }

        public PartyMember GetMemberByID(int id)
        {
            int i = 0;
            foreach (var item in GetAllMembers())
            {
                if (item.MemberID.Equals(id))
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
                throw new Exception($"No such member with ID '{id}'!");
            }
            else
                return memberRepo.GetOne(id);
        }
    }
}
