using AlloyOptimisation.Helpers;
using AlloyOptimisation.Models;
using NUnit.Framework;

namespace AlloyOptimisation.UnitTests.Helpers
{
    [TestFixture]
    internal class CompositionGeneratorTests
    {
        private List<Element> _elements;

        [SetUp]
        public void Setup()
        {
            _elements = new List<Element>
            {
                new Element("Iron", 0.5, 100, 10, 50, 10),
                new Element("Nickel", 0.8, 200, 5, 20, 5)
            };
        }

        [Test]
        public void Should_return_all_possible_compositions_within_ranges()
        {
            var generator = new CompositionGenerator(_elements);
            var compositions = generator.GenerateAllCompositions();

            Assert.That(compositions.Count, Is.GreaterThan(0));
            foreach (var composition in compositions)
            {
                double totalPercentage = composition.Sum(pair => pair.Value);
                Assert.That(totalPercentage, Is.LessThanOrEqualTo(100));
            }
        }
    }
}
