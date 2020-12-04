using Tax.Calculator.Helpers.Common;

namespace Tax.Calculator.Helpers.Calculators.Factory
{
    public class IncomeTaxCalculatorFactory : CalculatorFactory
    {
        private readonly decimal taxPercentage = GlobalConstants.TAX_INCOME_PERCENTAGE;

        public IncomeTaxCalculatorFactory(decimal? taxPercentage = null)
        {
            if (taxPercentage.HasValue)
            {
                this.taxPercentage = taxPercentage.Value;
            }
        }

        public override Calculator GetCalculator()
        {
            return new IncomeTaxCalculator(taxPercentage);
        }
    }
}
