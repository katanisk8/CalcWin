using Calculator.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalcWin.Views.Calculator
{
    public class CalculatorViewModel
    {
        // Start data
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<Flavor> Flavors { get; set; }

        // Wine Project
        public string Name { get; set; }
        public int SelectedFlavor { get; set; }
        public double SelectedAlcoholQuantity { get; set; }
        public double JuiceCorretion { get; set; }

        // Calculation results
        public Result Result { get; set; }
    }
}
