namespace CalcWin.Client.CalcService.Model
{
    public class Supplement
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool IsDefault { get; set; }
        public double Price { get; set; }
        public double Factor { get; set; }
    }
}
