using System.Collections.Generic;

namespace PayrollCalculationParser
{
    public interface ICalculation
    {
        string Name { get; }

        CalculationResult GetResult(CalculationResultsCollection calculationResultsCollection, CalculationInputs calculationInputs);

        IEnumerable<string> GetDependentCalculations();
    }
}