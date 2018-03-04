namespace Calculator.Models
{
    public interface ICalcWinElement
    {
        int Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; set; }
    }
}