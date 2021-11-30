using BV3N92_HFT_2021221.Models;
using System;
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

        private void Menu()
        {
            #region Menu UI

            Console.WriteLine("Welcome to the DbContext of inner politics!");
            Console.WriteLine("You have the opportunity to manage inner politics of many nations.");
            Console.WriteLine("That means you have a context consisting of parliaments, parties and party members.");
            Console.WriteLine("Each parliament has multiple parties, of which one of them is the ruling party.");
            Console.WriteLine("Each party has an ideology and multiple junior and senior party members.");
            Console.WriteLine("The following actions are availabe:");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("1. Create entity");
            Console.WriteLine("2. Create entity");
            Console.WriteLine("3. Create entity");
            Console.WriteLine("4. Create entity");
            Console.WriteLine("5. Create entity");
            Console.WriteLine("6. Create entity");
            Console.WriteLine("7. Create entity");
            Console.WriteLine("8. Create entity");
            Console.WriteLine("9. Create entity");
            Console.WriteLine("___________________________\n");
            Console.WriteLine("You can navigate the menu with the corresponding number keys.");
            Console.WriteLine("\nESC: Kilépés");

            #endregion

            ConsoleKey key = Console.ReadKey().Key;

            do
            {
                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine("1. Create Parliament");
                    Console.WriteLine("2. Create Party");
                    Console.WriteLine("3. Create Party Member");

                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("1. Get Parliament entities");
                    Console.WriteLine("2. Get Party entities");
                    Console.WriteLine("3. Get Party Member entities");

                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Console.WriteLine("1. Update Parliament entity");
                    Console.WriteLine("2. Update Party entity");
                    Console.WriteLine("3. Update Party Member entity");

                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Console.WriteLine("1. Delete Parliament entity");
                    Console.WriteLine("2. Delete Party entity");
                    Console.WriteLine("3. Delete Party Member entity");

                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
                {

                }
                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
                {

                }
                else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
                {

                }
                else if (key == ConsoleKey.D8 || key == ConsoleKey.NumPad8)
                {

                }
                else if (key == ConsoleKey.D9 || key == ConsoleKey.NumPad9)
                {

                }




            } while (key.Equals(ConsoleKey.Escape));
        }
    }
}
