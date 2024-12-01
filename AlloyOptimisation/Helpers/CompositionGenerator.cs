using AlloyOptimisation.Models;

namespace AlloyOptimisation.Helpers
{
    public class CompositionGenerator(List<Element> elements)
    {
        private readonly List<Element> _elements = elements;
        public List<List<KeyValuePair<Element, double>>> GenerateAllCompositions()
        {
            if (_elements.Count == 0) 
                return [];

            List<List<double>> elementRanges = _elements
                .Select(element => GenerateRange(element.MinPercent, element.MaxPercent, element.StepSize))
                .ToList();

            List<List<double>> compositions = CartesianProduct(elementRanges);

            List<List<KeyValuePair<Element, double>>> result = [];
            foreach (List<double> composition in compositions)
            {
                List<KeyValuePair<Element, double>> keyValuePairs = new List<KeyValuePair<Element, double>>();
                for (int i = 0; i < composition.Count; i++)
                {
                    keyValuePairs.Add(new KeyValuePair<Element, double>(_elements[i], composition[i]));
                }
                result.Add(keyValuePairs);
            }

            return result;
        }
        public static List<double> GenerateRange(double min, double max, double step)
        {
            List<double> range = [];
            for (double value = min; value <= max; value += step)
            {
                range.Add(value);
            }
            return range;
        }
        public static List<List<double>> CartesianProduct(List<List<double>> sequences)
        {
            return sequences.Aggregate(
                new List<List<double>> { new List<double>() },
                (accumulator, sequence) => accumulator
                    .SelectMany(combination => sequence, (combination, value) =>
                        new List<double>(combination) { value })
                    .ToList());
        }
    }
}
