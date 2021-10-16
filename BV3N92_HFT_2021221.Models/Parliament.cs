using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BV3N92_HFT_2021221.Models
{
    [Table("Parliament")]
    public class Parliament
    {
        [ForeignKey(nameof(Party))]
        public string Ruling_Party { get; set; }

        [Required]
        public string[] Parties { get; set; }
    }
}
