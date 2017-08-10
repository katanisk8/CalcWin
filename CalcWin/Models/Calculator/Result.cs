using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models.Calculator
{
    public class Result
    {
        public Juice Juice { get; set; }
        public Recipe Recipe { get; set; }
        public Wine Wine { get; set; }

        public Result()
        {
            Juice = new Juice();
            Recipe = new Recipe();
            Wine = new Wine();
        }
    }

    public class Juice
    {
        public double FruitsQuantity { get; set; }
        public double FruitsGrape { get; set; }
        public double SugarInGrape { get; set; }
        public double AcidInGrape { get; set; }
        public double JuiceQuantity { get; set; }
        public double SugarInJuice { get; set; }
        public double AcidInJuice { get; set; }
    }

    public class Recipe
    {
        public List<Ingredients> Ingredients { get; set; }
        public double Sugar { get; set; }
        public double Acid { get; set; }
        public double Water { get; set; }
        public double YeastFood { get; set; }
        public double Yeast { get; set; }
    }

    public class Wine
    {
        public string Color { get; set; }
        public double AlcoholQuantity { get; set; }
        public string Flavor { get; set; }
        public double Quantity { get; set; }
        public double IngredientsCost { get; set; }
        public double SuplementsCost { get; set; }
        public double TotalCost { get; set; }
        public double CostPerLiter { get; set; }
    }
}
