using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CalcWin.DataAccess.Model
{
    [Serializable]
    public class Fruit : IElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("name")]
        [Required]
        public string Name { get; set; }

        [XmlAttribute("isDefault")]
        [Required]
        public bool IsDefault { get; set; }

        [XmlAttribute("sugar")]
        [Required]
        public double Sugar { get; set; }

        [XmlAttribute("acid")]
        [Required]
        public double Acid { get; set; }

        [XmlAttribute("price")]
        [Required]
        public double Price { get; set; }
    }
}
