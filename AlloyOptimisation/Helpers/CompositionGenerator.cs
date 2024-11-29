using AlloyOptimisation.Models;

namespace AlloyOptimisation.Helpers
{
    public class CompositionGenerator(List<Element> elements)
    {
        private readonly List<Element> _elements = elements;
        public List<List<KeyValuePair<Element, double>>> GenerateAllCompositions()
        {
            List<List<double>> elementRanges = _elements
                .Select(element => GenerateRange(element.MinPercent, element.MaxPercent, element.StepSize))
                .ToList();

            List<List<double>> compositions = CartesianProduct(elementRanges);

            List<List<KeyValuePair<Element, double>>> result = new List<List<KeyValuePair<Element, double>>>();
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
        private static List<double> GenerateRange(double min, double max, double step)
        {
            List<double> range = new List<double>();
            for (double value = min; value <= max; value += step)
            {
                range.Add(value);
            }
            return range;
        }
        private static List<List<double>> CartesianProduct(List<List<double>> sequences)
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
