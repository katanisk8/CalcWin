using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Calculator.Models
{
    [Serializable]
    public class Supplement : ICalcWinElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
        [XmlIgnore]
        public WineProject Project { get; set; }
        
        [XmlAttribute("type")]
        public int Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public double Price { get; set; }

        [XmlAttribute("factor")]
        public double Factor { get; set; }

        [XmlAttribute("isDefault")]
        public bool IsDefault { get; set; }
    }
}
