using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models
{
    public class Flavor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        [Display(Name = "Flavor")]
        [StringLength(20, ErrorMessage = "Flavor name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }

        [Required]
        [Range(0, 10)]
        public double Acidity { get; set; }
    }
}
