using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Calculator.Models
{
    [Serializable]
    public class Fruit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
        public string User { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("sugar")]
        public double Sugar { get; set; }

        [XmlAttribute("acid")]
        public double Acid { get; set; }

        [XmlAttribute("price")]
        public double Price { get; set; }
        
        public string Image { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
