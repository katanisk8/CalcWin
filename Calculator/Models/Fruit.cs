using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
        public string User { get; set; }

        public Fruit Parent { get; set; }

        [Required]
        [Display(Name = "Fruit")]
        [StringLength(20, ErrorMessage = "Fruit name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }

        [Required]
        public double Sugar { get; set; }

        [Required]
        public double Acid { get; set; }

        [Required]
        public double Price { get; set; }
        
        public string Image { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
