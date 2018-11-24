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


        private static IList<Ingredient> GetIngredients(IEnumerable<CWDA.Ingredient> ingredients)
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

        private static Fruit GetFruit(CWDA.Fruit fruit)
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

        private static Flavor GetFlavor(CWDA.Flavor flavor)
        {
            Flavor newFlavor = new Flavor();
            newFlavor.Name = flavor.Name;
            newFlavor.NormalizedName = flavor.NormalizedName;
            newFlavor.IsDefault = flavor.IsDefault;
            newFlavor.Acid = flavor.Acid;

            return newFlavor;
        }

        private static IList<Supplement> GetSupelements(IEnumerable<CWDA.Supplement> suplements)
        {
            IList<Supplement> newSuplements = new List<Supplement>();

            foreach (var suplement in suplements)
            {
                Supplement newSupplement = new Supplement();
                newSupplement.Name = suplement.Name;
                newSupplement.NormalizedName = suplement.NormalizedName;
                newSupplement.IsDefault = suplement.IsDefault;
                newSupplement.Price = suplement.Price;
                newSupplement.Factor = suplement.Factor;

                newSuplements.Add(newSupplement);
            }

            return newSuplements;
        }
    }
}
