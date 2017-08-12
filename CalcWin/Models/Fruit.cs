using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models
{
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
        public ApplicationUser User { get; set; }

        public Fruit Parent { get; set; }

        [Required]
        [Display(Name = "Fruit")]
        [StringLength(20, ErrorMessage = "Fruit name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }

        [Required]
        [Range(1, 200)]
        public double Sugar { get; set; }

        [Required]
        [Range(1, 50)]
        public double Acid { get; set; }

        [Required]
        [Range(1, 100)]
        public double Price { get; set; }
        
        public string Image { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
