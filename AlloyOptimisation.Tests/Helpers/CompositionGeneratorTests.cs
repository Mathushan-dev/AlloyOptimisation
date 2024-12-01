using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using AlloyOptimisation.Models;
using AlloyOptimisation.Helpers;

namespace AlloyOptimisation.UnitTests.Helpers
{
    [TestFixture]
    internal class CompositionGeneratorTests
    {
        private CompositionGenerator _compositionGenerator;
        private List<Element> _elements;

        [SetUp]
        public void Setup()
        {
            _elements =
            [
                new Element("Iron", 0.5, 100, 10, 30, 10),
                new Element("Nickel", 0.8, 200, 5, 15, 5)
            ];
            _compositionGenerator = new CompositionGenerator(_elements);
        }

        [Test(Author = "MM")]
        public void Should_generate_all_compositions_with_correct_ranges()
        {
            List<List<KeyValuePair<Element, double>>> compositions = _compositionGenerator.GenerateAllCompositions();

            List<List<KeyValuePair<Element, double>>> expectedCompositions =
            [
                [new KeyValuePair<Element, double>(_elements[0], 10), new KeyValuePair<Element, double>(_elements[1], 5)],
                [new KeyValuePair<Element, double>(_elements[0], 10), new KeyValuePair<Element, double>(_elements[1], 10)],
                [new KeyValuePair<Element, double>(_elements[0], 10), new KeyValuePair<Element, double>(_elements[1], 15)],
                [new KeyValuePair<Element, double>(_elements[0], 20), new KeyValuePair<Element, double>(_elements[1], 5)],
                [new KeyValuePair<Element, double>(_elements[0], 20), new KeyValuePair<Element, double>(_elements[1], 10)],
                [new KeyValuePair<Element, double>(_elements[0], 20), new KeyValuePair<Element, double>(_elements[1], 15)],
                [new KeyValuePair<Element, double>(_elements[0], 30), new KeyValuePair<Element, double>(_elements[1], 5)],
                [new KeyValuePair<Element, double>(_elements[0], 30), new KeyValuePair<Element, double>(_elements[1], 10)],
                [new KeyValuePair<Element, double>(_elements[0], 30), new KeyValuePair<Element, double>(_elements[1], 15)]
            ];

            Assert.Multiple(() =>
            {
                Assert.That(compositions, Is.Not.Empty, "Compositions should not be empty.");
                Assert.That(compositions, Has.Count.EqualTo(3 * 3), "Expected 9 combinations.");
                Assert.That(compositions, Is.EquivalentTo(expectedCompositions));
            });
        }

        [Test(Author = "MM")]
        public void Should_return_empty_if_no_elements_provided()
        {
            CompositionGenerator emptyGenerator = new CompositionGenerator([]);

            List<List<KeyValuePair<Element, double>>> compositions = emptyGenerator.GenerateAllCompositions();

            Assert.That(compositions, Is.Empty);
        }

        [Test(Author = "MM")]
        public void Should_generate_correct_range_for_element()
        {
            List<double> range = CompositionGenerator.GenerateRange(5.0, 15.0, 5.0);

            Assert.That(range, Is.EquivalentTo(new List<double> { 5.0, 10.0, 15.0 }));
        }

        [Test(Author = "MM")]
        public void Should_calculate_correct_cartesian_product()
        {
            List<List<double>> sequences = new List<List<double>>
            {
                new() { 1.0, 2.0 },
                new() { 3.0, 4.0 }
            };

            List<List<double>> cartesianProduct = CompositionGenerator.CartesianProduct(sequences);

            List<List<double>> expected = new List<List<double>>
            {
                new() { 1.0, 3.0 },
                new() { 1.0, 4.0 },
                new() { 2.0, 3.0 },
                new() { 2.0, 4.0 }
            };

            Assert.That(cartesianProduct, Is.EquivalentTo(expected));
        }
    }
}