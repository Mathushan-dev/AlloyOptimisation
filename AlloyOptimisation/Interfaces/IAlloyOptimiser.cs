using AlloyOptimisation.Models;

namespace AlloyOptimisation.Interfaces
{
    public interface IAlloyOptimiser
    {
        /// <summary>
        /// Optimises the alloy composition to maximise creep resistance while staying within cost constraints.
        /// </summary>
        /// <returns>
        /// A tuple containing:
        /// <list type="bullet">
        /// <item><description><see cref="List{T}"/>: The optimal composition as a list of element-percentage pairs.</description></item>
        /// <item><description><see cref="double"/>: The maximum creep resistance achieved for the optimal composition.</description></item>
        /// <item><description><see cref="double"/>: The total cost of the optimal composition.</description></item>
        /// </list>
        /// </returns>
        (List<KeyValuePair<Element, double>> Composition, double TotalCreepResistance, double TotalCost) OptimiseAlloy();
    }
}