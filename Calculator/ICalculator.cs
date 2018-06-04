using Calculator.Model;
using System.Collections.Generic;

namespace Calculator
{
    public interface ICalculator
    {
        Result Calculate(IList<Ingredient> ingredients, Flavor flavor, double alcoholQuantity, double juiceCorretion, IList<Supplement> supplements);
    }
}