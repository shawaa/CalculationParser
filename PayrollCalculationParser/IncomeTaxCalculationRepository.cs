using System.Collections.Generic;

namespace PayrollCalculationParser
{
    public class IncomeTaxCalculationRepository
    {
        public IEnumerable<ICalculation> GetIncomeTaxCalculations()
        {
            return new List<ICalculation>
            {
                new DecimalCalculation("Taxable Pay 20%", (results, inputs)
                        => (decimal) results.GetResultValueFor("Gross Pay")
                           - (decimal) inputs.Dictionary["20% Tax Allowance"],
                    "Gross Pay"),

                new DecimalCalculation("Taxable Pay 50%", (results, inputs)
                        => (decimal) results.GetResultValueFor("Gross Pay")
                           - (decimal) inputs.Dictionary["50% Tax Allowance"],
                    "Gross Pay"),

                new DecimalCalculation("Tax 20%", (results, inputs) 
                        => (decimal) results.GetResultValueFor("Taxable Pay 20%") 
                           * 0.2m,
                    "Taxable Pay 20%"),

                new DecimalCalculation("Tax 50%", (results, inputs) 
                        => (decimal) results.GetResultValueFor("Taxable Pay 50%")
                           * 0.5m,
                    "Taxable Pay 50%"),

                new DecimalCalculation("Net Pay", (results, inputs) 
                        => (decimal) results.GetResultValueFor("Gross Pay")
                           - (decimal) results.GetResultValueFor("Tax 20%")
                           - (decimal) results.GetResultValueFor("Tax 50%"),
                    "Tax 20%", "Tax 50%", "Gross Pay"),

                new DecimalCalculation("Tax", (results, inputs)
                        => (decimal) results.GetResultValueFor("Tax 20%")
                           + (decimal) results.GetResultValueFor("Tax 50%"),
                    "Tax 20%", "Tax 50%")
            };
        }
    }
}