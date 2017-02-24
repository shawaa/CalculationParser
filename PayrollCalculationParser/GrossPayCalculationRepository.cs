using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PayrollCalculationParser
{
    public class GrossPayCalculationRepository
    {
        public IEnumerable<ICalculation> GetGrossPayCalculations()
        {
            return new List<ICalculation>
            {
                new DecimalCalculation("Bonus", (results, inputs) => (decimal) inputs.Dictionary["Bonus"]),
                new DecimalCalculation("Salary", (results, inputs) => (decimal) inputs.Dictionary["Salary"]),
                new DecimalCalculation("Gross Pay", (results, inputs) => (decimal) results.GetResultValueFor("Salary") + (decimal) results.GetResultValueFor("Bonus"), "Salary", "Bonus")
            };
        }

        public DecimalCalculation ParseDecimalCalculation(string calculation)
        {
            string[] split = calculation.Split('=');

            string resultName = split.First();
            string function = split.Last();

            Regex regex = new Regex(@"([a-zA-Z]\s?)+");
            var matches = regex.Matches(function);

            List<string> dependencies = new List<string>();

            foreach (Match match in matches)
            {
                dependencies.Add(match.Value);
            }

            Func<CalculationResultsCollection, CalculationInputs, decimal> func = GetFuncForFunction(function);
            return new DecimalCalculation(resultName, func, dependencies);
        }

        private Func<CalculationResultsCollection, CalculationInputs, decimal> GetFuncForFunction(string function)
        {
            
        }
    }
}