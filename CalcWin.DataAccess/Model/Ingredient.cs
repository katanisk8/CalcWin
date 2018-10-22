using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalcWin.DataAccess.Model
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public WineProject WineProject { get; set; }

        [Required]
        public Fruit Fruit { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}
