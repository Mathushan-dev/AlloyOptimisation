using AlloyOptimisation.Models;

namespace AlloyOptimisation.Helpers
{
    public class CostCalculator
    {
        private readonly Element _baseElement;

        public CostCalculator(Element baseElement)
        {
            _baseElement = baseElement;
        }

        public double CalculateTotalCost(double baseElementPercentage, List<KeyValuePair<Element, double>> otherElements)
        {
            double baseElementCost = _baseElement.CostPerKg * baseElementPercentage;

            double totalElementCost = otherElements.Sum(keyValuePair => keyValuePair.Key.CostPerKg * keyValuePair.Value);

            return (baseElementCost + totalElementCost) / 100;
        }
    }
}
