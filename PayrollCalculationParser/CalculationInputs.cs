using System.Collections.Generic;

namespace PayrollCalculationParser
{
    public class CalculationInputs
    {
        public IDictionary<string, object> Dictionary { get; }

        public CalculationInputs(IDictionary<string, object> dictionary)
        {
            Dictionary = dictionary;
        }
    }
}