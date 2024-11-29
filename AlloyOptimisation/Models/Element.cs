namespace AlloyOptimisation.Models
{
    public class Element(string name, double creepCoefficient, double costPerKg, double minPercent, double maxPercent, double stepSize)
    {
        private readonly string _name = name;
        private readonly double _creepCoefficient = creepCoefficient;
        private readonly double _costPerKg = costPerKg;
        private readonly double _minPercent = minPercent;
        private readonly double _maxPercent = maxPercent;
        private readonly double _stepSize = stepSize;
        public string Name => _name;
        public double CreepCoefficient => _creepCoefficient;
        public double CostPerKg => _costPerKg;
        public double MinPercent => _minPercent;
        public double MaxPercent => _maxPercent;
        public double StepSize => _stepSize;
    }
}
