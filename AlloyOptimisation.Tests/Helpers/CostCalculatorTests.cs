using AlloyOptimisation.Helpers;
using AlloyOptimisation.Models;

namespace AlloyOptimisation.UnitTests.Helpers
{
    [TestFixture]
    internal class CostCalculatorTests
    {
        private Element _baseElement;

        [SetUp]
        public void Setup()
        {
            _baseElement = new Element("Titanium", 1.5, 400, 20, 40, 5);
        }

        [Test]
        public void Should_calculate_total_cost_correctly()
        {
            CostCalculator calculator = new CostCalculator(_baseElement);
            List<KeyValuePair<Element, double>> elements = new List<KeyValuePair<Element, double>>
            {
                new KeyValuePair<Element, double>(new Element("Carbon", 0.7, 100, 10, 20, 5), 10),
                new KeyValuePair<Element, double>(new Element("Chromium", 0.8, 250, 5, 15, 5), 5)
            };

            double totalCost = calculator.CalculateTotalCost(85, elements);

            Assert.That(totalCost, Is.EqualTo(362.5));
        }
    }
}
