using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollCalculationParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            GrossPayCalculationRepository grossPayCalculationRepository = new GrossPayCalculationRepository();
            IncomeTaxCalculationRepository incomeTaxCalculationRepository = new IncomeTaxCalculationRepository();

            IEnumerable<ICalculation> grossPayCalculations = grossPayCalculationRepository.GetGrossPayCalculations();
            IEnumerable<ICalculation> incomeTaxCalculations = incomeTaxCalculationRepository.GetIncomeTaxCalculations();
            IEnumerable<ICalculation> calculations = grossPayCalculations.Concat(incomeTaxCalculations);

            CalculatorConfiguration calculatorConfiguration = new CalculatorConfiguration(calculations, "Gross Pay", "Net Pay", "Tax");
            Calculator calculator = new Calculator(calculatorConfiguration);

            CalculationInputs calculationInputs = new CalculationInputs(new Dictionary<string, object>
            {
                { "Bonus", 200m },
                { "Salary", 1500m },
                { "20% Tax Allowance", 400m },
                { "50% Tax Allowance", 1200m }
            });

            IEnumerable<CalculationOutput> result = calculator.CalculateAllOutputs(calculationInputs);

            foreach (CalculationOutput calculationOutput in result)
            {
                Console.WriteLine(calculationOutput.Calculation.Name + " = " + calculationOutput.Result);
            }
        }
    }
}
