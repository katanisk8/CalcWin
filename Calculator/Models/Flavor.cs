using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Calculator.Models
{
    [Serializable]
    public class Flavor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("acid")]
        public double Acidity { get; set; }
    }
}
