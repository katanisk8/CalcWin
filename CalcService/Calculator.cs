using System;
using System.Linq;
using CalcService.Model;
using System.Collections.Generic;

namespace CalcService
{
    public class Calculator : ICalculator
    {
        public Result Calculate(IList<Ingredient> ingredients, Flavor flavor, double alcoholQuantity, double juiceCorretion, IList<Supplement> supplements)
        {
            Result result = Calculate(ingredients, flavor, alcoholQuantity, supplements);

            if (IsJuiceCorrection(juiceCorretion))
            {
                IList<Ingredient> correctedIngredients = CorrectIngredients(result, juiceCorretion);

                return Calculate(correctedIngredients, flavor, alcoholQuantity, supplements);
            }

            return result;
        }

        private static bool IsJuiceCorrection(double juiceCorretion)
        {
            return juiceCorretion > 0;
        }

        private static IList<Ingredient> CorrectIngredients(Result result, double juiceCorretion)
        {
            IList<Ingredient> correctedIngredients = new List<Ingredient>();

            foreach (var ingredient in result.Recipe.Ingredients)
            {
                Ingredient newIngredient = new Ingredient();
                newIngredient.Fruit = ingredient.Fruit;
                newIngredient.Quantity = (ingredient.Quantity * juiceCorretion / result.Mixture.JuiceQuantity);

                correctedIngredients.Add(newIngredient);
            }

            return correctedIngredients;
        }

        private static Result Calculate(IList<Ingredient> ingredients, Flavor flavor, double alcoholQuantity, IList<Supplement> supplements)
        {
            CheckIngredients(ingredients);

            Result result = new Result();
            Supplement sugar = supplements.First(x => x.NormalizedName == "Sugar");
            Supplement acid = supplements.First(x => x.NormalizedName == "Acid");
            Supplement water = supplements.First(x => x.NormalizedName == "Water");
            Supplement yeast = supplements.First(x => x.NormalizedName == "Yeast");
            Supplement yeastFood = supplements.First(x => x.NormalizedName == "Yeast Food");

            double sugarSum = 0;
            double acidSum = 0;
            double grapeQuantity = 0;
            double fruitsCost = 0;
            double acidQuantity = 0;

            foreach (var item in ingredients)
            {
                Fruit fruit = item.Fruit;

                // Fruits quantity
                double kg = item.Quantity;
                result.Mixture.FruitsQuantity += kg;

                // Grape quantity
                double grape = (kg / 2);
                grapeQuantity += grape;

                // Sum of sugar and acid in grape
                sugarSum += grape * fruit.Sugar;
                acidSum += grape * fruit.Acid;

                //Frutis cost
                fruitsCost += kg * fruit.Price;
            }

            // Sugar and Acid in grape
            double sugarInGrape = sugarSum / grapeQuantity;
            double acidInGrape = acidSum / grapeQuantity;

            //Juice
            double waterQuantity = grapeQuantity;
            double juiceQuantity = grapeQuantity + waterQuantity;
            double sugarFromFruitsInJuice = sugarSum / juiceQuantity;
            double acidFromFruitsInJuice = acidSum / juiceQuantity;

            // Expected final quantity
            double esq = ExpectedSugarQuantity(alcoholQuantity);
            double eaq = flavor.Acid;
            
            // Water calculation
            if (acidFromFruitsInJuice > eaq)
            {
                // Add water
                waterQuantity = (acidInGrape / eaq * grapeQuantity) - grapeQuantity;
                juiceQuantity = grapeQuantity + waterQuantity;
            }
            else if (acidFromFruitsInJuice < eaq)
            {
                // Add acid
                acidQuantity = (eaq - acidFromFruitsInJuice) * juiceQuantity;
            }

            // Add sugar
            double sugarQuantity = ((esq * juiceQuantity) - sugarSum) / 1000;
            double sugarVolume = (sugarQuantity > 0) ? (sugarQuantity * 0.6) : 0;

            waterQuantity = waterQuantity - sugarVolume;

            // Final calculations
            double sugarInFinalJuice = sugarSum / juiceQuantity;
            double acidInFinalJuice = acidSum / juiceQuantity;

            double yeastfoodQuantity = juiceQuantity * yeastFood.Factor;
            double yeastQuantity = juiceQuantity * yeast.Factor;

            double wineQuantity = (grapeQuantity + waterQuantity + sugarVolume) * 0.9;

            double suplementsCost = (sugarQuantity * sugar.Price) +
                                    (acidQuantity / 1000 * acid.Price) +
                                    (waterQuantity * water.Price) +
                                    (yeastfoodQuantity / 1000 * yeastFood.Price) +
                                    (yeastQuantity / 1000 * yeast.Price);

            // Juice 
            result.Mixture.FruitsMixture = grapeQuantity;
            result.Mixture.SugarInMixture = sugarInGrape;
            result.Mixture.AcidInMixture = acidInGrape;
            result.Mixture.JuiceQuantity = juiceQuantity;
            result.Mixture.SugarInJuice = sugarInFinalJuice;
            result.Mixture.AcidInJuice = acidInFinalJuice;

            // Recipe
            result.Recipe.Ingredients = ingredients;
            result.Recipe.Water = waterQuantity;
            result.Recipe.Acid = acidQuantity;
            result.Recipe.Sugar = sugarQuantity;
            result.Recipe.YeastFood = yeastfoodQuantity;
            result.Recipe.Yeast = yeastQuantity;
            result.Recipe.SuplementsCost = suplementsCost;

            // Wine
            result.Wine.AlcoholQuantity = alcoholQuantity;
            result.Wine.Flavor = flavor.Name;
            result.Wine.Color = WineColor(ingredients);
            result.Wine.Quantity = wineQuantity;
            result.Wine.TotalCost = (fruitsCost + suplementsCost);
            result.Wine.CostPerLiter = (result.Wine.TotalCost / wineQuantity);

            return result;
        }

        private static void CheckIngredients(IList<Ingredient> ingredients)
        {
            if (ingredients == null || !ingredients.Any())
                throw new ArgumentException(nameof(ingredients));
        }

        private static double ExpectedSugarQuantity(double expectedAlcoholPercent)
        {
            // 17.18 sugar quantity for each 1% of alcohol
            return expectedAlcoholPercent * 17.18;
        }

        private static string WineColor(IList<Ingredient> Componentts)
        {
            return "?";
        }
    }
}
