using AlloyOptimisation.Models;
using NUnit.Framework;

namespace AlloyOptimisation.UnitTests.Models
{
    [TestFixture]
    internal class ElementTests
    {
        [Test]
        public void Should_create_element_with_correct_properties()
        {
            var element = new Element("Zinc", 0.6, 120, 5, 25, 5);

            Assert.That(element.Name, Is.EqualTo("Zinc"));
            Assert.That(element.CreepCoefficient, Is.EqualTo(0.6));
            Assert.That(element.CostPerKg, Is.EqualTo(120));
            Assert.That(element.MinPercent, Is.EqualTo(5));
            Assert.That(element.MaxPercent, Is.EqualTo(25));
            Assert.That(element.StepSize, Is.EqualTo(5));
        }
    }
}
