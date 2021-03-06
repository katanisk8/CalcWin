﻿using CalcWin.Client.CalcService.Model;
using CalcWin.DataAccess.Model;
using System.Collections.Generic;

namespace CalcWin.Client.CalcService.Mappers
{
    public class CalcServiceRequestMapper : ICalcServiceRequestMapper
    {
        public CalcServiceRequest MapCalcServiceRequest(IList<Ingredient> ingredients, Flavor flavor, double selectedAlcoholQuantity, double juiceCorretion, IList<Supplement> suplements)
        {
            CalcServiceRequest request = new CalcServiceRequest();
            request.Ingredients = GetIngredients(ingredients);
            request.Flavor = GetFlavor(flavor);
            request.AlcoholQuantity = selectedAlcoholQuantity;
            request.JuiceCorretion = juiceCorretion;
            request.Supplements = GetSupelements(suplements);

            return request;
        }


        private static IList<IngredientDTO> GetIngredients(IEnumerable<Ingredient> ingredients)
        {
            IList<IngredientDTO> newIngredients = new List<IngredientDTO>();

            foreach (var ingredient in ingredients)
            {
                IngredientDTO newIngredient = new IngredientDTO();
                newIngredient.Fruit = GetFruit(ingredient.Fruit);
                newIngredient.Quantity = ingredient.Quantity;

                newIngredients.Add(newIngredient);
            }

            return newIngredients;
        }

        private static FruitDTO GetFruit(Fruit fruit)
        {
            FruitDTO newFruit = new FruitDTO();
            newFruit.Sugar = fruit.Sugar;
            newFruit.Acid = fruit.Acid;
            newFruit.Price = fruit.Price;

            return newFruit;
        }

        private static FlavorDTO GetFlavor(Flavor flavor)
        {
            FlavorDTO newFlavor = new FlavorDTO();
            newFlavor.Name = flavor.Name;
            newFlavor.Acid = flavor.Acid;

            return newFlavor;
        }

        private static IList<SupplementDTO> GetSupelements(IEnumerable<Supplement> suplements)
        {
            IList<SupplementDTO> newSuplements = new List<SupplementDTO>();

            foreach (var suplement in suplements)
            {
                SupplementDTO newSupplement = new SupplementDTO();
                newSupplement.Type = suplement.Type;
                newSupplement.IsDefault = suplement.IsDefault;
                newSupplement.Price = suplement.Price;
                newSupplement.Factor = suplement.Factor;

                newSuplements.Add(newSupplement);
            }

            return newSuplements;
        }
    }
}
