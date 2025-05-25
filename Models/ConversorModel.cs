namespace APIConversao.Models
{
    public class ConversorModel
    {
        public double Value { get; set; }
        public string FromUnit { get; set; } = null!;
        public string ToUnit { get; set; } = null!;
    }
}
