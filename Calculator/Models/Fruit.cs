using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Calculator.Models
{
    [Serializable]
    public class Fruit : ICalcWinElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("sugar")]
        public double Sugar { get; set; }

        [XmlAttribute("acid")]
        public double Acid { get; set; }

        [XmlAttribute("price")]
        public double Price { get; set; }

        [XmlIgnore]
        public string Image { get; set; }

        [XmlIgnore]
        public string Description { get; set; }

        [XmlIgnore]
        public string Link { get; set; }

        [XmlAttribute("isDefault")]
        public bool IsDefault { get; set; }
    }
}
