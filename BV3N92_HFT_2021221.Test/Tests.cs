using BV3N92_HFT_2021221.Data;
using BV3N92_HFT_2021221.Logic;
using BV3N92_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Test
{
    [TestFixture]
    public class Tests
    {
        ParliamentLogic parliamentLogic;
        PartyLogic partyLogic;
        
        [OneTimeSetUp]
        public void Setup()
        {
            ParliamentAdministrationDbContext db = new ParliamentAdministrationDbContext();

            IParliamentRepository repo = new ParliamentRepository(db);
            IPartyRepository prepo = new PartyRepository(db);
            IPartyMemberRepository pmrepo = new PartyMemberRepository(db);

            parliamentLogic = new ParliamentLogic(repo,prepo);
            partyLogic = new PartyLogic(prepo, pmrepo);
        }

        [Test]
        public void GetAllRulingPartiesIsCorrect()
        {
            Assert.That(parliamentLogic.GetAllRulingParties().ToList().Count == partyLogic.GetAllParties().Count);
        }

        [Test]
        public void GetSameIdeologyMembersIsCorrect()
        {
            Assert.That(partyLogic.GetSameIdeologyMembers(Models.Ideologies.Nationalist).ToList().Count == 5);
        }

        [Test]
        public void GetJuniorMembersIsCorrect()
        {
            Assert.That(partyLogic.GetJuniorMembers(1).ToList().Count == 2);
        }

        [Test]
        public void GetSeniorMembersIsCorrect()
        {
            Assert.That(partyLogic.GetJuniorMembers(1).ToList().Count == 2);
        }

        [Test]
        public void GetShortNamedMembersIsCorrect()
        {
            Assert.That(partyLogic.GetShortNamedMembers(1,6).ToList().Count == 3);
        }
    }
}
