namespace APIConversao.Service
{
    public class LenghtConversorService
    {
        private readonly Dictionary<string, double> unitToMeter = new()
        {
            {"mm", 0.001},
            {"cm", 0.01},
            {"m", 1},
            {"km", 1000},
            {"in", 0.0254},
            {"ft", 0.3048},
            {"yd", 0.9144},
            {"mi", 1609.34}
        };
        public double Convert(double value, string fromUnit, string toUnit)
        {
            if (!unitToMeter.ContainsKey(fromUnit) || !unitToMeter.ContainsKey(toUnit))
            {
                throw new ArgumentException("Unidade Inválida");
            }
            fromUnit = fromUnit.Trim().ToLower();
            toUnit = toUnit.Trim().ToLower();

            if (!unitToMeter.ContainsKey(fromUnit))
                throw new ArgumentException($"Unidade de origem inválida: {fromUnit}");

            if (!unitToMeter.ContainsKey(toUnit))
                throw new ArgumentException($"Unidade de destino inválida: {toUnit}");

            double valueInMeters = value * unitToMeter[fromUnit];
            return valueInMeters / unitToMeter[toUnit];
        }
    }
}
