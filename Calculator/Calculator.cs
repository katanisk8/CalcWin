using System;
using System.Linq;
using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.BussinesLogic
{
    public static class Calculations
    {
        public static Result CalculateWine(List<Ingredient> listElements, Flavor selectedFlavor, double expectedAlcohol, double juiceCorretion, Supplements suplements)
        {
            var result = CalculateHelper(listElements, selectedFlavor, expectedAlcohol, suplements);

            if (juiceCorretion > 0)
            {
                var correctedList = CorrectComponentts(result, juiceCorretion);
                return CalculateHelper(correctedList, selectedFlavor, expectedAlcohol, suplements);
            }

            return result;
        }


        private static List<Ingredient> CorrectComponentts(Result orginalResult, double juiceCorretion)
        {
            List<Ingredient> correctedList = new List<Ingredient>();

            foreach (var item in orginalResult.Recipe.Ingredients)
            {
                var newElement = new Ingredient
                {
                    Fruit = item.Fruit,
                    Quantity = (item.Quantity * juiceCorretion / orginalResult.Mixture.JuiceQuantity)
                };
                correctedList.Add(newElement);
            }
            return correctedList;
        }


        private static Result CalculateHelper(List<Ingredient> listElements, Flavor selectedFlavor, double expectedAlcohol, Supplements suplements)
        {
            if (listElements == null || !listElements.Any())
                throw new ArgumentException(nameof(listElements));

            Result result = new Result();

            double sugarSum = 0;
            double acidSum = 0;
            double grapeQuantity = 0;
            double fruitsCost = 0;

            // Calculation of basic Componenttsc (Grape)
            foreach (var item in listElements)
            {
                // Fruit
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
            double esq = ExpectedSugarQuantity(expectedAlcohol);
            double eaq = selectedFlavor.Acidity;

            double acidQuantity = 0;

            // Water calculation
            if (acidFromFruitsInJuice > eaq)
            {
                // Add water
                waterQuantity = ((acidInGrape / eaq) * grapeQuantity) - grapeQuantity;
                juiceQuantity = grapeQuantity + waterQuantity;
                sugarFromFruitsInJuice = sugarSum / juiceQuantity;
                acidFromFruitsInJuice = acidSum / juiceQuantity;
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

            double yeastfoodQuantity = juiceQuantity * suplements.YeastFood.Factor;
            double yeastQuantity = juiceQuantity * suplements.Yeast.Factor;

            double wineQuantity = (grapeQuantity + waterQuantity + sugarVolume) * 0.9;

            double suplementsCost = (sugarQuantity * suplements.Sugar.Price) +
                                    (acidQuantity / 1000 * suplements.Acid.Price) +
                                    (waterQuantity * suplements.Water.Price) +
                                    (yeastfoodQuantity / 1000 * suplements.YeastFood.Price) +
                                    (yeastQuantity / 1000 * suplements.Yeast.Price);

            // Juice 
            result.Mixture.FruitsMixture = grapeQuantity;
            result.Mixture.SugarInMixture = sugarInGrape;
            result.Mixture.AcidInMixture = acidInGrape;
            result.Mixture.JuiceQuantity = juiceQuantity;
            result.Mixture.SugarInJuice = sugarFromFruitsInJuice;
            result.Mixture.AcidInJuice = acidFromFruitsInJuice;

            // Recipe
            result.Recipe.Ingredients = listElements;
            result.Recipe.Water = waterQuantity;
            result.Recipe.Acid = acidQuantity;
            result.Recipe.Sugar = sugarQuantity;
            result.Recipe.YeastFood = yeastfoodQuantity;
            result.Recipe.Yeast = yeastQuantity;
            result.Recipe.SuplementsCost = suplementsCost;

            // Wine
            result.Wine.AlcoholQuantity = expectedAlcohol;
            result.Wine.Flavor = selectedFlavor.Name;
            result.Wine.Color = WineColor(listElements);
            result.Wine.Quantity = wineQuantity;
            result.Wine.TotalCost = (fruitsCost + suplementsCost);
            result.Wine.CostPerLiter = (result.Wine.TotalCost / wineQuantity);

            return result;
        }

        private static double ExpectedSugarQuantity(double expectedAlcoholPercent)
        {
            // 17.18 sugar quantity for each 1% of alcohol
            return (expectedAlcoholPercent * 17.18);
        }

        private static string WineColor(List<Ingredient> Componentts)
        {
            return "?";
        }

    }
}
