using CalcWin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CalcWin.Views.Calculator
{
    public class CalculatorViewModel
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public SelectList Flavors { get; set; }

        public string Name { get; set; }
        public int SelectedFlavor { get; set; }
        public double SelectedAlcoholQuantity { get; set; }
    }
}
