using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public class Supplements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public string User { get; set; }
        
        [Required]
        public Suplement Water { get; set; }

        [Required]
        public Suplement Sugar { get; set; }

        [Required]
        public Suplement Acid { get; set; }

        [Required]
        public Suplement Yeast { get; set; }

        [Required]
        public Suplement YeastFood { get; set; }
    }
}
