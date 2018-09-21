using System.Collections.Generic;
using CalcService.Model;

namespace CalcWin.Client.CalcService
{
   public interface ICalcService
   {
      Result Calculate(IList<Ingredient> ingredients, Flavor flavor, double selectedAlcoholQuantity, double juiceCorretion, IList<Supplement> suplements);
   }
}