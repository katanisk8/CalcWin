using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CalcWin.DataAccess.Model
{
    [Serializable]
    public class Supplement : IElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
        [XmlIgnore]
        public WineProject WineProject { get; set; }
        
        [XmlAttribute("name")]
        [Required]
        public string Name { get; set; }

        [XmlAttribute("normalizedName")]
        [Required]
        public string NormalizedName { get; set; }

        [XmlAttribute("type")]
        [Required]
        public SuplementType Type { get; set; }

        [XmlAttribute("isDefault")]
        [Required]
        public bool IsDefault { get; set; }

        [XmlAttribute("price")]
        [Required]
        public double Price { get; set; }

        [XmlAttribute("factor")]
        public double Factor { get; set; }
    }
    
    public enum SuplementType
    {
        [XmlEnum("0")]
        Sugar = 0,
        [XmlEnum("1")]
        Acid = 1,
        [XmlEnum("2")]
        Water = 2,
        [XmlEnum("3")]
        Yeast = 3,
        [XmlEnum("4")]
        YeastFood = 4
    }
}
