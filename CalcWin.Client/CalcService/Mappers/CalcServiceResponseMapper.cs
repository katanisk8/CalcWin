using System.Collections.Generic;
using CalcWin.Client.CalcService.Model;
using CWDA = CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService.Mappers
{
    public class CalcServiceResponseMapper : ICalcServiceResponseMapper
    {
        public CWDA.Result MapCalcServiceResponse(CalcServiceResponse response)
        {
            CWDA.Result result = new CWDA.Result();

            result.Mixture = GetMixture(response.Result.Mixture);
            result.Recipe = GetRecipe(response.Result.Recipe);
            result.Wine = GetWine(response.Result.Wine);

            return result;
        }

        private CWDA.Mixture GetMixture(Mixture resultMixture)
        {
            CWDA.Mixture mixture = new CWDA.Mixture();
            mixture.FruitsQuantity = resultMixture.FruitsQuantity;
            mixture.FruitsMixture = resultMixture.FruitsMixture;
            mixture.SugarInMixture = resultMixture.SugarInMixture;
            mixture.AcidInMixture = resultMixture.AcidInMixture;
            mixture.JuiceQuantity = resultMixture.JuiceQuantity;
            mixture.SugarInJuice = resultMixture.SugarInJuice;
            mixture.AcidInJuice = resultMixture.AcidInJuice;

            return mixture;
        }

        private CWDA.Recipe GetRecipe(Recipe resultRecipe)
        {
            CWDA.Recipe recipe = new CWDA.Recipe();
            recipe.Ingredients = GetIngredients(resultRecipe.Ingredients);
            recipe.Sugar = resultRecipe.Sugar;
            recipe.Acid = resultRecipe.Acid;
            recipe.Water = resultRecipe.Water;
            recipe.YeastFood = resultRecipe.YeastFood;
            recipe.Yeast = resultRecipe.Yeast;
            recipe.SuplementsCost = resultRecipe.SuplementsCost;

            return recipe;
        }

        private CWDA.Wine GetWine(Wine resultWine)
        {
            CWDA.Wine wine = new CWDA.Wine();
            wine.Color = resultWine.Color;
            wine.AlcoholQuantity = resultWine.AlcoholQuantity;
            wine.Flavor = resultWine.Flavor;
            wine.Quantity = resultWine.Quantity;
            wine.CostPerLiter = resultWine.CostPerLiter;
            wine.TotalCost = resultWine.TotalCost;

            return wine;
        }

        private static IList<CWDA.Ingredient> GetIngredients(IList<Ingredient> ingredients)
        {
            IList<CWDA.Ingredient> newIngredients = new List<CWDA.Ingredient>();

            foreach (var ingredient in ingredients)
            {
                CWDA.Ingredient newIngredient = new CWDA.Ingredient();
                newIngredient.Fruit = GetFruit(ingredient.Fruit);
                newIngredient.Quantity = ingredient.Quantity;
                
                newIngredients.Add(newIngredient);
            }

            return newIngredients;
        }

        private static CWDA.Fruit GetFruit(Fruit fruit)
        {
            CWDA.Fruit newFruit = new CWDA.Fruit();
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
