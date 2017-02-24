using System.Collections.Generic;
using System.Linq;

namespace PayrollCalculationParser
{
    public class CalculatorConfiguration
    {
        private readonly IEnumerable<ICalculation> _calculations;

        private readonly IEnumerable<string> _outputCalculations;

        public CalculatorConfiguration(IEnumerable<ICalculation> calculations, params string[] outputCalculations)
        {
            _calculations = calculations;
            _outputCalculations = outputCalculations;
        }

        public IEnumerable<string> GetAllOutputCalculationNames()
        {
            return _outputCalculations;
        }

        public ICalculation GetCalculationForName(string name)
        {
            return _calculations.SingleOrDefault(x => x.Name == name);
        }
    }
}