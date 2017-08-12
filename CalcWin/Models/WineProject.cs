using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models
{
    public class WineProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        [Required]
        [Display(Name = "Flavor")]
        [StringLength(20, ErrorMessage = "Flavor name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }

        [Required]
        public Flavor Flavor { get; set; }

        [Required]
        [Display(Name = "Alcohol Quantity")]
        public double AlcoholQuantity { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
