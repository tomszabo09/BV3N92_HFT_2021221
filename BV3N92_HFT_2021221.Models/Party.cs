using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Models
{
    [Table("Parties")]
    public class Party
    {
        [Key]
        public string PartyName { get; set; }

        //[ForeignKey(nameof(Party_Member))]
        //public int Member_ID { get; set; }

        [ForeignKey(nameof(Parliament))]
        public string ParliamentName { get; set; }

        [MaxLength(20)]
        public string Ideology { get; set; }

        [NotMapped]
        public virtual ICollection<Party_Member> PartyMembers { get; set; } //navigation property

        [NotMapped]
        public virtual Parliament Parliament { get; set; }
    }
}
