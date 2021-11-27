using BV3N92_HFT_2021221.Models;
using System.Threading;

namespace BV3N92_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:41126");

            //rest.Post<Parliament>(new Parliament()
            //{
            //    ParliamentName = "Parliament of Tests",
            //    RulingParty = "Party of Tests"
            //}, "parliament");

            var rulingparties = rest.Get<Party>("stat/getallrulingparties");
            var shortnamedmembers = rest.GetById<PartyMember>(1, "stat/getshortnamedmembers");
            var seniormembers = rest.GetById<PartyMember>(1,"stat/getseniormembers");
            var juniormembers = rest.GetById<PartyMember>(1,"stat/getjuniormembers");
            var sameideologymembers = rest.GetSameIdeologies<PartyMember>(Ideologies.Nationalist.ToString(), "stat/getsameideologymembers");

            var parliaments = rest.Get<Parliament>("parliament");
            var parties = rest.Get<Party>("party");
            var members = rest.Get<PartyMember>("partymember");

            ;
        }
    }
}
