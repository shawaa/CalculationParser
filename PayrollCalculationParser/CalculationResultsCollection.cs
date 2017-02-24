using System.Collections.Generic;
using System.Linq;

namespace PayrollCalculationParser
{
    public class CalculationResultsCollection
    {
        private readonly IList<CalculationResult> _calculationResults;

        public CalculationResultsCollection()
        {
            _calculationResults = new List<CalculationResult>();
        }

        public void AddResult(CalculationResult result)
        {
            _calculationResults.Add(result);
        }

        public object GetResultValueFor(string calculation)
        {
            return _calculationResults.SingleOrDefault(x => x.CalculationName == calculation)?.Result;
        }
    }
}