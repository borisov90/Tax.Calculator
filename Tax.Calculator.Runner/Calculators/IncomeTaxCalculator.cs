using Tax.Calculator.Helpers.Common;
using Tax.Calculator.Helpers.Enums;

namespace Tax.Calculator.Helpers.Calculators
{
    public class IncomeTaxCalculator : Calculator
    {
        private readonly decimal taxPercentage;
        private readonly CalculatorType calculatorType;

        public IncomeTaxCalculator(decimal taxPercentage)
        {
            this.taxPercentage = taxPercentage;
            this.calculatorType = CalculatorType.Income;
        }

        public override decimal TaxPercentage
        {
            get { return this.taxPercentage; }
        }

        public override CalculatorType CalculatorType
        {
            get { return calculatorType; }
        }

        public override decimal CalculateTax(decimal taxableIncome)
        {
            return taxableIncome * (taxPercentage / GlobalConstants.ONE_HUNDRED);
        }
    }
}
