using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV3N92_HFT_2021221.Models
{
    [Table("Parliament")]
    public class Parliament
    {
        [Key]
        [Required]
        public string ParliamentName { get; set; }

        [ForeignKey(nameof(Party))]
        public string Ruling_Party { get; set; }

        [NotMapped]
        public virtual ICollection<Party> Parties { get; set; }
    }
}
