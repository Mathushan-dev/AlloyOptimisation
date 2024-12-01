using AlloyOptimisation.Functions;
using AlloyOptimisation.Models;

namespace AlloyOptimisation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Element baseElement = new Element("Ni", creepCoefficient: 0, costPerKg: 8.9, minPercent: 0, maxPercent: 100, stepSize: 1);

            AlloySystem alloySystem = new AlloySystem(baseElement, 
                [
                    new Element("Cr", 2.0911350e16, 14, 14.5, 22, 0.5),
                    new Element("Co", 7.2380280e16, 80.5, 0, 25, 1.0),
                    new Element("Nb", 1.0352738e16, 42.5, 0, 1.5, 0.1),
                    new Element("Mo", 8.9124547e16, 16, 1.5, 6, 0.5)
                ]);

            AlloyOptimiser optimiser = new AlloyOptimiser(alloySystem, 18);
            (List<KeyValuePair<Element, double>> optimalComposition, double maxCreepResistance, double totalCost) = optimiser.OptimiseAlloy();

            Console.WriteLine("Optimal Alloy Composition:");
            foreach (KeyValuePair<Element, double> element in optimalComposition)
            {
                Console.WriteLine($"  Element: {element.Key.Name + " " + element.Value.ToString():0.0}%");
            }
            Console.WriteLine($"Max Creep Resistance: {maxCreepResistance:e}");
            Console.WriteLine($"Total Cost: {totalCost:0.00} £/kg");
        }
    }
}