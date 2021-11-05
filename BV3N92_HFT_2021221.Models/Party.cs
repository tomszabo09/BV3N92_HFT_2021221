﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Models
{
    public enum Ideologies
    {
        Socialist, Conservative, Nationalist
    }

    [Table("Parties")]
    public class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartyID { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string PartyName { get; set; }

        [ForeignKey(nameof(Parliament))]
        public int ParliamentID { get; set; }

        [MaxLength(30)]
        [Required]
        public string ParliamentName { get; set; }

        [MaxLength(20)]
        [Required]
        public Ideologies Ideology { get; set; }

        [NotMapped]
        public virtual ICollection<Party_Member> PartyMembers { get; set; }

        [NotMapped]
        public virtual Parliament Parliament { get; set; }
    }
}
