using Tax.Calculator.Helpers.Common;

namespace Tax.Calculator.Helpers.Calculators.Factory
{
    public class SocialContributionsCalculatorFactory : CalculatorFactory
    {
        private readonly decimal taxPercentage = GlobalConstants.SOCIAL_CONTRIBUTIONS_PERCENTAGE;

        public SocialContributionsCalculatorFactory(decimal? taxPercentage = null)
        {
            if (taxPercentage.HasValue)
            {
                this.taxPercentage = taxPercentage.Value;
            }
        }

        public override Calculator GetCalculator()
        {
            return new SocialContributionsCalculator(taxPercentage);
        }
    }
}
