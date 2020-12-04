using Tax.Calculator.Helpers.Enums;

namespace Tax.Calculator.Helpers.Calculators
{
    public abstract class Calculator
    {
        public abstract decimal TaxPercentage { get; }
        public abstract CalculatorType CalculatorType { get; }
        public abstract decimal CalculateTax(decimal taxableIncome);
    }
}
