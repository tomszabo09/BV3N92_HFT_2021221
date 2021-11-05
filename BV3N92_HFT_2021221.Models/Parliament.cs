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
        public int ID { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string ParliamentName { get; set; }

        [ForeignKey(nameof(Party))]
        public string Ruling_Party { get; set; }

        [NotMapped]
        public virtual ICollection<Party> Parties { get; set; }
    }
}
