using System;

namespace PayrollCalculationParser
{
    public class CalculationOutput
    {
        public CalculationOutput(ICalculation calculation, object result)
        {
            Calculation = calculation;
            Result = result;
        }

        public ICalculation Calculation { get; }

        public object Result { get; }
    }
}