using System.Collections.Generic;

namespace DataAccess.Model
{
    public class Result
    {
        public Mixture Mixture { get; set; }
        public Recipe Recipe { get; set; }
        public Wine Wine { get; set; }

        public Result()
        {
            Mixture = new Mixture();
            Recipe = new Recipe();
            Wine = new Wine();
            Recipe.Ingredients = new List<Ingredient>();
        }
    }

    public class Mixture
    {
        public double FruitsQuantity { get; set; }
        public double FruitsMixture { get; set; }
        public double SugarInMixture { get; set; }
        public double AcidInMixture { get; set; }
        public double JuiceQuantity { get; set; }
        public double SugarInJuice { get; set; }
        public double AcidInJuice { get; set; }
    }

    public class Recipe
    {
        public IList<Ingredient> Ingredients { get; set; }
        public double Sugar { get; set; }
        public double Acid { get; set; }
        public double Water { get; set; }
        public double YeastFood { get; set; }
        public double Yeast { get; set; }
        public double SuplementsCost { get; set; }
    }

    public class Wine
    {
        public string Color { get; set; }
        public double AlcoholQuantity { get; set; }
        public string Flavor { get; set; }
        public double Quantity { get; set; }
        public double CostPerLiter { get; set; }
        public double TotalCost { get; set; }
    }
}