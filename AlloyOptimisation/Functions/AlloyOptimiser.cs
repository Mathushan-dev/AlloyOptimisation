using AlloyOptimisation.Helpers;
using AlloyOptimisation.Interfaces;
using AlloyOptimisation.Models;

namespace AlloyOptimisation.Functions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AlloyOptimiser"/> class.
    /// </summary>
    /// <param name="alloySystem">The alloy system containing the base element and other elements to consider in the composition.</param>
    /// <param name="maxCost">The maximum allowable cost per kilogram of the alloy.</param>
    public class AlloyOptimiser(AlloySystem alloySystem, double maxCost) : IAlloyOptimiser
    {
        private readonly Element _baseElement = alloySystem.BaseElement;
        private readonly List<Element> _otherElements = alloySystem.Elements;
        private readonly double _maxCost = maxCost;
        private readonly CompositionGenerator _compositionGenerator = new CompositionGenerator(alloySystem.Elements);
        private readonly CostCalculator _costCalculator = new CostCalculator(alloySystem.BaseElement);

        /// <summary>
        /// Finds the optimal alloy composition that maximises creep resistance within the given cost constraint.
        /// </summary>
        /// <returns>
        /// A tuple containing:
        /// <list type="bullet">
        /// <item><description><see cref="List{T}"/>: The optimal composition as a list of element-percentage pairs.</description></item>
        /// <item><description><see cref="double"/>: The maximum creep resistance achieved for the optimal composition.</description></item>
        /// <item><description><see cref="double"/>: The total cost of the optimal composition.</description></item>
        /// </list>
        /// </returns>
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
                    optimalComposition = [new KeyValuePair<Element, double> (_baseElement, baseElementPercentage), .. composition];

                    optimalTotalCreepResistance = totalCreepResistance;
                    optimalTotalCost = totalCost;
                }
            }

            return (optimalComposition, optimalTotalCreepResistance, optimalTotalCost);
        }
    }
}