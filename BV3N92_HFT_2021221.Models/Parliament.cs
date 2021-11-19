using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV3N92_HFT_2021221.Models
{
    [Table("Parliaments")]
    public class Parliament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParliamentID { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string ParliamentName { get; set; }

        [Required]
        public string RulingParty { get; set; }

        [NotMapped]
        public virtual ICollection<Party> Parties { get; set; }
    }
}
