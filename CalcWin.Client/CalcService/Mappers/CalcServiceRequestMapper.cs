using CalcWin.Client.CalcService.Model;
using CWDA = CalcWin.DataAccess.Model;
using System.Collections.Generic;

namespace CalcWin.Client.CalcService.Mappers
{
    public class CalcServiceRequestMapper : ICalcServiceRequestMapper
    {
        public CalcServiceRequest MapCalcServiceRequest(IList<CWDA.Ingredient> ingredients, CWDA.Flavor flavor, double selectedAlcoholQuantity, double juiceCorretion, IList<CWDA.Supplement> suplements)
        {
            CalcServiceRequest request = new CalcServiceRequest();
            request.Ingredients = GetIngredients(ingredients);
            request.Flavor = GetFlavor(flavor);
            request.AlcoholQuantity = selectedAlcoholQuantity;
            request.JuiceCorretion = juiceCorretion;
            request.Supplements = GetSupelements(suplements);

            return request;
        }


        private static IList<IngredientDTO> GetIngredients(IEnumerable<CWDA.Ingredient> ingredients)
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

        private static FruitDTO GetFruit(CWDA.Fruit fruit)
        {
            FruitDTO newFruit = new FruitDTO();
            newFruit.Name = fruit.Name;
            newFruit.NormalizedName = fruit.NormalizedName;
            newFruit.IsDefault = fruit.IsDefault;
            newFruit.Sugar = fruit.Sugar;
            newFruit.Acid = fruit.Acid;
            newFruit.Price = fruit.Price;

            return newFruit;
        }

        private static FlavorDTO GetFlavor(CWDA.Flavor flavor)
        {
            FlavorDTO newFlavor = new FlavorDTO();
            newFlavor.Name = flavor.Name;
            newFlavor.NormalizedName = flavor.NormalizedName;
            newFlavor.IsDefault = flavor.IsDefault;
            newFlavor.Acid = flavor.Acid;

            return newFlavor;
        }

        private static IList<SupplementDTO> GetSupelements(IEnumerable<CWDA.Supplement> suplements)
        {
            IList<SupplementDTO> newSuplements = new List<SupplementDTO>();

            foreach (var suplement in suplements)
            {
                SupplementDTO newSupplement = new SupplementDTO();
                newSupplement.Name = suplement.Name;
                newSupplement.NormalizedName = suplement.NormalizedName;
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
