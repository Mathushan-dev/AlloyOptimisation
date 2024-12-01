using AlloyOptimisation.Helpers;
using AlloyOptimisation.Models;

namespace AlloyOptimisation.UnitTests.Helpers
{
    [TestFixture]
    internal class CreepResistanceCalculatorTests
    {
        [Test]
        public void Should_calculate_total_creep_resistance_correctly()
        {
            List<KeyValuePair<Element, double>> elements = new List<KeyValuePair<Element, double>>
            {
                new KeyValuePair<Element, double>(new Element("Iron", 0.5, 100, 10, 50, 10), 30),
                new KeyValuePair<Element, double>(new Element("Nickel", 0.8, 200, 5, 20, 5), 20)
            };

            CreepResistanceCalculator creepResistanceCalculator = new CreepResistanceCalculator(elements);
            double totalCreepResistance = creepResistanceCalculator.CalculateTotalCreepResistance();

            Assert.That(totalCreepResistance, Is.EqualTo(31));
        }
    }
}