namespace Calculator.Models
{
    public class Supplements
    {
        public Supplement Water { get; set; }
        public Supplement Sugar { get; set; }
        public Supplement Acid { get; set; }
        public Supplement Yeast { get; set; }
        public Supplement YeastFood { get; set; }
    }

    public enum SupplementType
    {
        Water,
        Sugar,
        Acid,
        Yeast,
        YeastFood
    }
}
