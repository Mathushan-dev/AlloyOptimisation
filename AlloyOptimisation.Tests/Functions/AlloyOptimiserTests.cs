using AlloyOptimisation.Functions;
using AlloyOptimisation.Models;

namespace AlloyOptimisation.UnitTests.Functions
{
    [TestFixture]
    internal class AlloyOptimiserTests
    {
        private Element _baseElement;
        private List<Element> _otherElements;

        [SetUp]
        public void Setup()
        {
            _baseElement = new Element("Aluminum", 1.2, 150, 40, 60, 5);
            _otherElements = new List<Element>
            {
                new Element("Copper", 0.9, 300, 10, 30, 10),
                new Element("Magnesium", 1.1, 200, 5, 20, 5)
            };
        }

        [Test]
        public void Should_optimise_alloy_with_valid_compositions()
        {
            var optimiser = new AlloyOptimiser(_baseElement, _otherElements, 500);
            var (composition, creepResistance, cost) = optimiser.OptimiseAlloy();

            Assert.That(composition, Is.Not.Empty);
            Assert.That(creepResistance, Is.GreaterThan(0));
            Assert.That(cost, Is.LessThanOrEqualTo(500));
        }
    }
}
