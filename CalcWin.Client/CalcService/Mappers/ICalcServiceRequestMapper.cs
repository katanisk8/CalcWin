using CalcWin.Client.CalcService.Model;
using CWDA = CalcWin.DataAccess.Model;
using System.Collections.Generic;

namespace CalcWin.Client.CalcService.Mappers
{
    public interface ICalcServiceRequestMapper
    {
        CalcServiceRequest MapCalcServiceRequest(IList<CWDA.Ingredient> ingredients, CWDA.Flavor flavor,
            double selectedAlcoholQuantity, double juiceCorretion, IList<CWDA.Supplement> suplements);
    }
}