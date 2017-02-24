namespace PayrollCalculationParser
{
    public class CalculationResult
    {
        public string CalculationName { get; }

        public object Result { get; }

        public CalculationResult(string calculationName, object result)
        {
            CalculationName = calculationName;
            Result = result;
        }
    }
}