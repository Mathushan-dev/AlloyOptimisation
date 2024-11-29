using AlloyOptimisation.Models;

namespace AlloyOptimisation.Interfaces
{
    public interface IAlloyOptimiser
    {
        (List<KeyValuePair<Element, double>> Composition, double TotalCreepResistance, double TotalCost) OptimiseAlloy();
    }
}