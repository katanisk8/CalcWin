using System.Collections.Generic;
using System.Threading.Tasks;
using CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService
{
    public interface ICalcService
    {
        Task<Result> InitialAsync(IList<Ingredient> ingredients, Flavor flavor, double selectedAlcoholQuantity, double juiceCorretion, IList<Supplement> suplements);
    }
}