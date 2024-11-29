namespace AlloyOptimisation.Models
{
    public class AlloySystem(double maxCost, Element baseElement)
    {
        private readonly List<Element> _elements = new List<Element>();
        private readonly Element _baseElement = baseElement;
        private readonly double _maxCost = maxCost;
        public List<Element> Elements => _elements;
        public Element BaseElement => _baseElement;
        public double MaxCost => _maxCost;
        public void AddElement(Element element)
        {
            _elements.Add(element);
        }
        public void RemoveElement(Element element)
        {
            _elements.Remove(element);
        }
    }
}