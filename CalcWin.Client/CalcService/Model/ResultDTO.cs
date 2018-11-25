using System.Collections.Generic;

namespace CalcWin.Client.CalcService.Model
{
    public class ResultDTO
    {
        public MixtureDTO Mixture { get; set; }
        public RecipeDTO Recipe { get; set; }
        public WineDTO Wine { get; set; }

        public ResultDTO()
        {
            Mixture = new MixtureDTO();
            Recipe = new RecipeDTO();
            Wine = new WineDTO();
            Recipe.Ingredients = new List<IngredientDTO>();
        }
    }

    public class MixtureDTO
    {
        public double FruitsQuantity { get; set; }
        public double FruitsMixture { get; set; }
        public double SugarInMixture { get; set; }
        public double AcidInMixture { get; set; }
        public double JuiceQuantity { get; set; }
        public double SugarInJuice { get; set; }
        public double AcidInJuice { get; set; }
    }

    public class RecipeDTO
    {
        public IList<IngredientDTO> Ingredients { get; set; }
        public double Sugar { get; set; }
        public double Acid { get; set; }
        public double Water { get; set; }
        public double YeastFood { get; set; }
        public double Yeast { get; set; }
        public double SuplementsCost { get; set; }
    }

    public class WineDTO
    {
        public string Color { get; set; }
        public double AlcoholQuantity { get; set; }
        public string Flavor { get; set; }
        public double Quantity { get; set; }
        public double CostPerLiter { get; set; }
        public double TotalCost { get; set; }
    }
}