namespace AlloyOptimisation.Models
{
    public class AlloySystem(Element baseElement, List<Element>? elements = null)
    {
        private readonly List<Element> _elements = elements ?? [];
        private readonly Element _baseElement = baseElement;

        public List<Element> Elements => _elements;
        public Element BaseElement => _baseElement;

        public void AddElement(Element elementToAdd)
        {
            _elements.Add(elementToAdd);
        }

        public void AddRangeOfElements(IEnumerable<Element> elementsToAdd)
        {
            foreach (Element elementToAdd in elementsToAdd)
            {
                _elements.Add(elementToAdd);
            }
        }

        public void RemoveElement(Element elementToRemove)
        {
            _elements.Remove(elementToRemove);
        }

        public void RemoveRangeOfElements(IEnumerable<Element> elementsToRemove)
        {
            _elements.RemoveAll(elementToRemove => elementsToRemove.Contains(elementToRemove));
        }

    }
}
