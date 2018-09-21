using CalcService.Model;
using System.Collections.Generic;

namespace CalcService
{
    public interface ICalculator
    {
        Result Calculate(IList<Ingredient> ingredients, Flavor flavor, double alcoholQuantity, double juiceCorretion, IList<Supplement> supplements);
    }
}