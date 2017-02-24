using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollCalculationParser
{
    public class DecimalCalculation : ICalculation
    {
        private readonly Func<CalculationResultsCollection, CalculationInputs, decimal> _calculation;

        private readonly string[] _depedentCalculations;

        public DecimalCalculation(string name, Func<CalculationResultsCollection, CalculationInputs, decimal> calculation, IEnumerable<string> depedentCalculations)
        {
            _calculation = calculation;
            Name = name;
            _depedentCalculations = depedentCalculations.ToArray();
        }

        public DecimalCalculation(string name, Func<CalculationResultsCollection, CalculationInputs, decimal> calculation, params string[] depedentCalculations)
        {
            _calculation = calculation;
            Name = name;
            _depedentCalculations = depedentCalculations;
        }

        public CalculationResult GetResult(CalculationResultsCollection calculationResultsCollection, CalculationInputs calculationInputs)
        {
            return new CalculationResult(Name, _calculation(calculationResultsCollection, calculationInputs));
        }

        public IEnumerable<string> GetDependentCalculations()
        {
            return _depedentCalculations;
        }

        public string Name { get; }
    }
}