using AlloyOptimisation.Helpers;
using AlloyOptimisation.Interfaces;
using AlloyOptimisation.Models;

namespace AlloyOptimisation.Functions
{
    public class AlloyOptimiser(Element baseElement, List<Element> otherElements, double maxCost) : IAlloyOptimiser
    {
        private readonly Element _baseElement = baseElement;
        private readonly List<Element> _otherElements = otherElements;
        private readonly double _maxCost = maxCost;
        private readonly CompositionGenerator _compositionGenerator = new CompositionGenerator(otherElements);
        private readonly CostCalculator _costCalculator = new CostCalculator(baseElement);

        public (List<KeyValuePair<Element, double>> Composition, double TotalCreepResistance, double TotalCost) OptimiseAlloy()
        {
            List<KeyValuePair<Element, double>> optimalComposition = [];
            double optimalTotalCreepResistance = 0;
            double optimalTotalCost = 0;

            foreach (List<KeyValuePair<Element, double>> composition in _compositionGenerator.GenerateAllCompositions())
            {
                double baseElementPercentage = 100 - composition.Sum(keyValuePair => keyValuePair.Value);
                if (baseElementPercentage < _baseElement.MinPercent || baseElementPercentage > _baseElement.MaxPercent)
                    continue;

                double totalCreepResistance = new CreepResistanceCalculator(composition).CalculateTotalCreepResistance();
                double totalCost = _costCalculator.CalculateTotalCost(baseElementPercentage, composition);

                if (totalCost <= _maxCost && totalCreepResistance > optimalTotalCreepResistance)
                {
                    optimalComposition = new List<KeyValuePair<Element, double>> { new KeyValuePair<Element, double> (_baseElement, baseElementPercentage) };
                    optimalComposition.AddRange(composition);

                    optimalTotalCreepResistance = totalCreepResistance;
                    optimalTotalCost = totalCost;
                }
            }

            return (optimalComposition, optimalTotalCreepResistance, optimalTotalCost);
        }
    }
}