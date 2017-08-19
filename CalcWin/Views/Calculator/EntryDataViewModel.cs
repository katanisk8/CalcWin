using CalcWin.Data;
using CalcWin.Models;
using System.Collections.Generic;

namespace CalcWin.Views.Calculator
{
    public class EntryDataViewModel
    {
        public List<Fruit> Fruits { get; set; }
        public List<Flavor> Flavors { get; set; }

        public List<Ingredient> SelectedFruits { get; set; }
        public Flavor SelectedFlavor {get; set;}
        public double SelectedAlcoholQuantity;


    }
}
