using CalcWin.DataAccess.Model;
using System.Collections.Generic;

namespace CalcService.Core.Model
{
    public class CalcServiceRequest
    {
        public IList<Ingredient> Ingredients { get; set; }
        public Flavor Flavor { get; set; }
        public double AlcoholQuantity { get; set; }
        public double JuiceCorretion { get; set; }
        public IList<Supplement> Supplements { get; set; }
    }
}
