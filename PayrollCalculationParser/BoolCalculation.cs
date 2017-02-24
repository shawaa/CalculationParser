using System;
using System.Collections.Generic;

namespace PayrollCalculationParser
{
    public class BoolCalculation : ICalculation
    {
        private readonly Func<CalculationResultsCollection, CalculationInputs, bool> _calculation;

        private readonly string[] _depedentCalculations;

        public BoolCalculation(string name, Func<CalculationResultsCollection, CalculationInputs, bool> calculation, params string[] depedentCalculations)
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