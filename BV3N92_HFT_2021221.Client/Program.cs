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

            var parliaments = rest.Get<Parliament>("parliament");
            var parties = rest.Get<Party>("party");
            var members = rest.Get<PartyMember>("partymember");
        }
    }
}
