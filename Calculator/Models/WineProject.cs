using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Calculator.Models
{
    [Serializable]
    public class WineProject
    {
        [XmlAttribute("project")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Timestamp]
        public byte[] Timestamp { get; set; }

        [XmlIgnore]
        [Required]
        public string User { get; set; }

        [XmlIgnore]
        public IEnumerable<Ingredient> Ingredients { get; set; }

        [XmlIgnore]
        [Required]
        [Display(Name = "Project Name")]
        [StringLength(20, ErrorMessage = "Flavor name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Name { get; set; }

        [XmlIgnore]
        [Required]
        public Flavor Flavor { get; set; }

        [XmlIgnore]
        [Required]
        [Display(Name = "Alcohol Quantity")]
        public double AlcoholQuantity { get; set; }

        [XmlIgnore]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
