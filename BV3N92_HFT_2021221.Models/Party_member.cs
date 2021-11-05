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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID {get; set;}

        [ForeignKey(nameof(Party))]
        public int PartyID { get; set; }

        [Required]
        public string PartyName { get; set; }

        [Range(18,int.MaxValue)]
        public int Age { get; set; }

        [MaxLength(20)]
        [Required]
        public string Last_Name { get; set; }
        
        [NotMapped]
        public virtual Party Party { get; set; }
    }
}
