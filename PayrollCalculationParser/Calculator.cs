using System.Collections.Generic;
using System.Linq;

namespace PayrollCalculationParser
{
    public class Calculator
    {
        private readonly CalculatorConfiguration _calculatorConfiguration;

        public Calculator(CalculatorConfiguration calculatorConfiguration)
        {
            _calculatorConfiguration = calculatorConfiguration;
        }

        public IEnumerable<CalculationOutput> CalculateAllOutputs(CalculationInputs calculationInputs)
        {
            IEnumerable<string> allOutputsCalculations = _calculatorConfiguration.GetAllOutputCalculationNames();
            IList<CalculationOutput> calculationOutputs = new List<CalculationOutput>();
            CalculationResultsCollection calculationResultsCollection = new CalculationResultsCollection();

            foreach (string calculationName in allOutputsCalculations)
            {
                ICalculation calculation = _calculatorConfiguration.GetCalculationForName(calculationName);
                Calculate(calculation, calculationResultsCollection, calculationInputs);
                calculationOutputs.Add(new CalculationOutput(calculation, calculationResultsCollection.GetResultValueFor(calculationName)));
            }

            return calculationOutputs;
        }

        private void Calculate(ICalculation calculation, CalculationResultsCollection calculationResultsCollection, CalculationInputs calculationInputs)
        {
            if (calculationResultsCollection.GetResultValueFor(calculation.Name) != null)
            {
                return;
            }

            calculation.GetDependentCalculations().ToList().ForEach(x => Calculate(_calculatorConfiguration.GetCalculationForName(x), calculationResultsCollection, calculationInputs));

            CalculationResult result = calculation.GetResult(calculationResultsCollection, calculationInputs);
            calculationResultsCollection.AddResult(result);
        }
    }
}