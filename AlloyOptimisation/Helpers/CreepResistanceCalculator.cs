using AlloyOptimisation.Models;

namespace AlloyOptimisation.Helpers
{
    public class CreepResistanceCalculator(List<KeyValuePair<Element, double>> elements)
    {
        private readonly List<KeyValuePair<Element, double>> _elements = elements;
        public double CalculateTotalCreepResistance()
        {
            double creepResistance = 0;

            foreach (KeyValuePair<Element, double> elementPair in _elements)
            {
                creepResistance += elementPair.Key.CreepCoefficient * elementPair.Value;
            }

            return creepResistance;
        }
    }
}