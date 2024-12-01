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
            _alloySystem = new AlloySystem(_baseElement);
        }

        [Test(Author = "MM")]
        public void Should_initialise_with_base_element_and_empty_elements_list()
        {
            Assert.That(_alloySystem.BaseElement, Is.EqualTo(_baseElement));
            Assert.That(_alloySystem.Elements, Is.Empty);
        }

        [Test(Author = "MM")]
        public void Should_initialise_with_base_element_and_provided_elements()
        {
            List<Element> elements =
            [
                new Element("Element1", 0.8, 200, 10, 30, 5),
                new Element("Element2", 0.9, 250, 5, 20, 5)
            ];

            _alloySystem = new AlloySystem(_baseElement, elements);

            Assert.That(_alloySystem.Elements, Is.EquivalentTo(elements));
        }

        [Test(Author = "MM")]
        public void Should_add_and_remove_elements()
        {
            Element element = new Element("SecondaryElement", 0.8, 200, 10, 30, 5);

            _alloySystem.AddElement(element);
            Assert.That(_alloySystem.Elements, Contains.Item(element));

            _alloySystem.RemoveElement(element);
            Assert.That(_alloySystem.Elements, Does.Not.Contain(element));
        }

        [Test(Author = "MM")]
        public void Should_add_range_of_elements()
        {
            List<Element> elementsToAdd =
            [
                new Element("Element1", 0.7, 180, 5, 25, 5),
                new Element("Element2", 0.6, 150, 10, 30, 5)
            ];

            _alloySystem.AddRangeOfElements(elementsToAdd);

            foreach (Element element in elementsToAdd)
            {
                Assert.That(_alloySystem.Elements, Contains.Item(element));
            }
        }

        [Test(Author = "MM")]
        public void Should_remove_range_of_elements()
        {
            List<Element> elements =
            [
                new Element("Element1", 0.7, 180, 5, 25, 5),
                new Element("Element2", 0.6, 150, 10, 30, 5)
            ];

            _alloySystem = new AlloySystem(_baseElement, elements);

            _alloySystem.RemoveRangeOfElements(elements);

            foreach (Element element in elements)
            {
                Assert.That(_alloySystem.Elements, Does.Not.Contain(element));
            }
        }
    }
}