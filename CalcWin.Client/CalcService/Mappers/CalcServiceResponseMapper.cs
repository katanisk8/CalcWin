using System.Collections.Generic;
using CalcWin.Client.CalcService.Model;
using CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService.Mappers
{
    public class CalcServiceResponseMapper : ICalcServiceResponseMapper
    {
        public Result MapCalcServiceResponse(CalcServiceResponse response)
        {
            Result result = new Result();

            result.Mixture = GetMixture(response.Result.Mixture);
            result.Recipe = GetRecipe(response.Result.Recipe);
            result.Wine = GetWine(response.Result.Wine);

            return result;
        }

        private Mixture GetMixture(MixtureDTO resultMixture)
        {
            Mixture mixture = new Mixture();
            mixture.FruitsQuantity = resultMixture.FruitsQuantity;
            mixture.FruitsMixture = resultMixture.FruitsMixture;
            mixture.SugarInMixture = resultMixture.SugarInMixture;
            mixture.AcidInMixture = resultMixture.AcidInMixture;
            mixture.JuiceQuantity = resultMixture.JuiceQuantity;
            mixture.SugarInJuice = resultMixture.SugarInJuice;
            mixture.AcidInJuice = resultMixture.AcidInJuice;

            return mixture;
        }

        private Recipe GetRecipe(RecipeDTO resultRecipe)
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients = GetIngredients(resultRecipe.Ingredients);
            recipe.Sugar = resultRecipe.Sugar;
            recipe.Acid = resultRecipe.Acid;
            recipe.Water = resultRecipe.Water;
            recipe.YeastFood = resultRecipe.YeastFood;
            recipe.Yeast = resultRecipe.Yeast;
            recipe.SuplementsCost = resultRecipe.SuplementsCost;

            return recipe;
        }

        private Wine GetWine(WineDTO resultWine)
        {
            Wine wine = new Wine();
            wine.Color = resultWine.Color;
            wine.AlcoholQuantity = resultWine.AlcoholQuantity;
            wine.Flavor = resultWine.Flavor;
            wine.Quantity = resultWine.Quantity;
            wine.CostPerLiter = resultWine.CostPerLiter;
            wine.TotalCost = resultWine.TotalCost;

            return wine;
        }

        private static IList<Ingredient> GetIngredients(IList<IngredientDTO> ingredients)
        {
            IList<Ingredient> newIngredients = new List<Ingredient>();

            foreach (var ingredient in ingredients)
            {
                Ingredient newIngredient = new Ingredient();
                newIngredient.Fruit = GetFruit(ingredient.Fruit);
                newIngredient.Quantity = ingredient.Quantity;
                
                newIngredients.Add(newIngredient);
            }

            return newIngredients;
        }

        private static Fruit GetFruit(FruitDTO fruit)
        {
            Fruit newFruit = new Fruit();
            newFruit.Name = fruit.Name;
            newFruit.NormalizedName = fruit.NormalizedName;
            newFruit.IsDefault = fruit.IsDefault;
            newFruit.Sugar = fruit.Sugar;
            newFruit.Acid = fruit.Acid;
            newFruit.Price = fruit.Price;

            return newFruit;
        }
    }
}
