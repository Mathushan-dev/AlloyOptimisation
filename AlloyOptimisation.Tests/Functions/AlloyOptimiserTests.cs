using AlloyOptimisation.Functions;
using AlloyOptimisation.Models;

namespace AlloyOptimisation.UnitTests.Functions
{
    [TestFixture]
    internal class AlloyOptimiserTests
    {
        private AlloyOptimiser _alloyOptimiser;

        [SetUp]
        public void Setup()
        {
            Element baseElement = new Element("Ni", 0, 8.9, 0, 100, 1);

            List<Element> elements =
            [
                new Element("Cr", 2.0911350e16, 14, 14.5, 22, 0.5),
                new Element("Co", 7.2380280e16, 80.5, 0, 25, 1.0),
                new Element("Nb", 1.0352738e16, 42.5, 0, 1.5, 0.1),
                new Element("Mo", 8.9124547e16, 16, 1.5, 6, 0.5)
            ];

            AlloySystem alloySystem = new AlloySystem(baseElement, elements);

            double maxCost = 18;

            _alloyOptimiser = new AlloyOptimiser(alloySystem, maxCost);
        }

        [Test(Author = "MM")]
        public void Should_calculate_optimal_alloy_composition()
        {
            (List<KeyValuePair<Element, double>> optimalComposition, double maxCreepResistance, double totalCost) = _alloyOptimiser.OptimiseAlloy();

            Assert.Multiple(() =>
            {
                Assert.That(optimalComposition, Has.Count.EqualTo(5));

                Dictionary<string, double> expectedComposition = new Dictionary<string, double>
                {
                    { "Ni", 60.9 },
                    { "Cr", 22.0 },
                    { "Co", 10.0 },
                    { "Nb", 1.1 },
                    { "Mo", 6.0 }
                };

                foreach (KeyValuePair<Element, double> composition in optimalComposition)
                {
                    string elementName = composition.Key.Name;
                    Assert.That(expectedComposition.ContainsKey(elementName));
                    Assert.That(composition.Value, Is.EqualTo(expectedComposition[elementName]).Within(0.1));
                }

                Assert.That(maxCreepResistance, Is.EqualTo(1.729988e18).Within(1e14));

                Assert.That(totalCost, Is.EqualTo(17.98).Within(0.01));
            });
        }

        [Test(Author = "MM")]
        public void Should_respect_max_cost_constraint()
        {
            (List<KeyValuePair<Element, double>> _, double _, double totalCost) = _alloyOptimiser.OptimiseAlloy();

            Assert.That(totalCost, Is.LessThanOrEqualTo(18));
        }

        [Test(Author = "MM")]
        public void Should_return_empty_composition_if_no_valid_solution()
        {
            Element baseElement = new Element("Ni", 0, 8.9, 0, 100, 1);

            List<Element> invalidElements =
            [
                new Element("Cr", 2.0911350e16, 100, 14.5, 22, 0.5),
                new Element("Co", 7.2380280e16, 100, 0, 25, 1.0)
            ];

            AlloySystem alloySystem = new AlloySystem(baseElement, invalidElements);
            AlloyOptimiser optimiser = new AlloyOptimiser(alloySystem, 10);

            (List<KeyValuePair<Element, double>> optimalComposition, double maxCreepResistance, double totalCost) = optimiser.OptimiseAlloy();

            Assert.Multiple(() =>
            {
                Assert.That(optimalComposition, Is.Empty);
                Assert.That(maxCreepResistance, Is.EqualTo(0));
                Assert.That(totalCost, Is.EqualTo(0));
            });
        }
    }
}
