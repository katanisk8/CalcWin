using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CalcWin.DataAccess.Model
{
    public class NormalizedName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [XmlAttribute("item")]
        [Required]
        public string Item { get; set; }

        [XmlAttribute("name")]
        [Required]
        public string Name { get; set; }
    }
}
