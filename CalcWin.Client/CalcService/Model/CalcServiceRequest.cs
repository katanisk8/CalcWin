using System.Collections.Generic;

namespace CalcWin.Client.CalcService.Model
{
    public class CalcServiceRequest
    {
        public IList<IngredientDTO> Ingredients { get; set; }
        public FlavorDTO Flavor { get; set; }
        public double AlcoholQuantity { get; set; }
        public double JuiceCorretion { get; set; }
        public IList<SupplementDTO> Supplements { get; set; }
    }
}
