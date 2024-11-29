using AlloyOptimisation.Models;

namespace AlloyOptimisation.UnitTests.Models
{
    [TestFixture]
    internal class AlloySystemTests
    {
        private AlloySystem _alloySystem;
        private Element _baseElement;

        [SetUp]
        public void Setup()
        {
            _baseElement = new Element("BaseElement", 1.0, 300, 50, 70, 5);
            _alloySystem = new AlloySystem(1000, _baseElement);
        }

        [Test]
        public void Should_add_and_remove_elements()
        {
            var element = new Element("SecondaryElement", 0.8, 200, 10, 30, 5);

            _alloySystem.AddElement(element);
            Assert.That(_alloySystem.Elements, Contains.Item(element));

            _alloySystem.RemoveElement(element);
            Assert.That(_alloySystem.Elements, Does.Not.Contain(element));
        }
    }
}
