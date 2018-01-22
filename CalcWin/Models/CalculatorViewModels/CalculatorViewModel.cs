using Calculator.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CalcWin.Views.Calculator
{
   public class CalculatorViewModel
   {
      // Start data
      public IEnumerable<Ingredient> Ingredients { get; set; }
      public IEnumerable<Flavor> Flavors { get; set; }

      // Wine Project
      [Required]
      [Display(Name = "Project Name")]
      [StringLength(20, ErrorMessage = "Flavor name cannot be longer than 20 characters.")]
      [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
      public string Name { get; set; }

      [Required]
      public int SelectedFlavor { get; set; }

      [Required]
      public double SelectedAlcoholQuantity { get; set; }

      [Required]
      public double JuiceCorretion { get; set; }

      // Calculation results
      public Result Result { get; set; }
   }
}
