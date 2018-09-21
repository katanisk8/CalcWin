using DataAccess.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalcWin.Views.Calculator
{
   public class CalculatorViewModel
   {
      // Start data
      public IList<Ingredient> Ingredients { get; set; }
      public SelectList Flavors { get; set; }

        // Wine Project
        public string Name { get; set; }
      public int SelectedFlavor { get; set; }
      public double SelectedAlcoholQuantity { get; set; }
      public double JuiceCorretion { get; set; }

      // Calculation results
      public Result Result { get; set; }
   }
}
