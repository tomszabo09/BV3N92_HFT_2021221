using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Models
{
    [Table("Party members")]
    public class Party_Member
    {
        [Key]
        public int MemberID { get; set; }

        [Range(18,int.MaxValue)]
        public int Age { get; set; }

        [MaxLength(50)]
        public string Last_Name { get; set; }

        [NotMapped]
        public virtual Party Party { get; set; } //navigation property
    }
}
