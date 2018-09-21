using System.Collections.Generic;
using CalcService.Model;

namespace CalcWin.Client.CalcService
{
   public class CalcService : ICalcService
   {
      public Result Calculate(IList<Ingredient> ingredients, Flavor flavor, double selectedAlcoholQuantity, double juiceCorretion, IList<Supplement> suplements)
      {
         throw new System.NotImplementedException();
      }
   }
}
