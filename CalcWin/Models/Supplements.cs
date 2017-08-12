using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models
{
    public class Supplements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
        
        [Required]
        public double Water { get; set; }

        [Required]
        public double Sugar { get; set; }

        [Required]
        public double Acid { get; set; }

        [Required]
        public double Yeast { get; set; }

        [Required]
        public double YeastFood { get; set; }
    }
}
