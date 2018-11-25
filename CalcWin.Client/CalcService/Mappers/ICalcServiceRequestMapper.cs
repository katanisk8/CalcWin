using CalcWin.Client.CalcService.Model;
using System.Collections.Generic;
using CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService.Mappers
{
    public interface ICalcServiceRequestMapper
    {
        CalcServiceRequest MapCalcServiceRequest(IList<Ingredient> ingredients, Flavor flavor,
            double selectedAlcoholQuantity, double juiceCorretion, IList<Supplement> suplements);
    }
}