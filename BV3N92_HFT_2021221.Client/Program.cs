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

            //rest.Post<Party>(new Party()
            //{
            //    ParliamentID = 2,
            //    PartyName = "Test Party",
            //    Ideology = Ideologies.Conservative.ToString()
            //}, "party");

            //rest.Post<PartyMember>(new PartyMember()
            //{
            //    LastName = "TestName",
            //    Age = 50,
            //    PartyID = 5
            //}, "partymember");

            //rest.Delete(4, "parliament");
            //rest.Delete(3, "party");
            //rest.Delete(3, "partymember");

            //rest.Put<Parliament>(new Parliament()
            //{
            //    ParliamentID = 1,
            //    ParliamentName = "Bundestag",
            //    RulingParty = "NSDAP"
            //}, "parliament");

            //rest.Put<Party>(new Party()
            //{
            //    PartyID = 4,
            //    ParliamentID = 3,
            //    PartyName = "Hungarian Conservative Party",
            //    Ideology = Ideologies.Conservative.ToString()
            //}, "party");

            //rest.Put<PartyMember>(new PartyMember()
            //{
            //    MemberID = 6,
            //    LastName = "von Schacht",
            //    Age = 24,
            //    PartyID = 7
            //}, "partymember");

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
