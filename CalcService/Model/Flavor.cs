﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CalcService.Model
{
    [Serializable]
    public class Flavor : IElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [XmlAttribute("name")]
        [Required]
        public string Name { get; set; }

        [XmlAttribute("normalizedName")]
        [Required]
        public string NormalizedName { get; set; }

        [XmlAttribute("isDefault")]
        [Required]
        public bool IsDefault { get; set; }

        [XmlAttribute("acid")]
        [Required]
        public double Acid { get; set; }
    }
}
