using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public class Supplement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public WineProject WineProject { get; set; }

        [Required]
        public double Name { get; set; }

        [Required]
        public double Price { get; set; }

        public double Factor { get; set; }
    }
}
