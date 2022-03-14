using BV3N92_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_GUI_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Parliament> Parliaments { get; set; }
        public RestCollection<Party> Parties { get; set; }
        public RestCollection<PartyMember> PartyMembers { get; set; }

        public MainWindowViewModel()
        {
            Parliaments = new RestCollection<Parliament>("http://localhost:41126/", "parliament");
            Parties = new RestCollection<Party>("http://localhost:41126/", "party");
            PartyMembers = new RestCollection<PartyMember>("http://localhost:41126/", "partymember");
        }
    }
}
