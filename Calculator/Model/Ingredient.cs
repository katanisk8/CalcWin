﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required]
        public WineProject Project { get; set; }

        [Required]
        public Fruit Fruit { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}