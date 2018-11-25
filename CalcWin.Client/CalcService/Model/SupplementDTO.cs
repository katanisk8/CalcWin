using CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService.Model
{
    public class SupplementDTO
    {
        public SuplementType Type { get; set; }
        public bool IsDefault { get; set; }
        public double Price { get; set; }
        public double Factor { get; set; }
    }
}
