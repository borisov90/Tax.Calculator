namespace Tax.Calculator.Helpers.Common
{
    public class GlobalConstants
    {
        #region Numerical Constants
        public const decimal MINIMUM_TAXABLE_INCOME = 1000;
        public const decimal DEDUCTABLE_INCOME = 1000;
        public const decimal MAXIMUM_SOCIAL_INCOME = 3000;
        public const decimal TAX_INCOME_PERCENTAGE = 10;
        public const decimal SOCIAL_CONTRIBUTIONS_PERCENTAGE = 15;
        public const decimal ONE_HUNDRED = 100;
        public const decimal MAXIMUM_TAXABLE_INCOME_FOR_SOCIAL = 3000;
        public const decimal DEFAULT_VALUE = 0;
        #endregion

        #region String Constants
        public const string  INVALID_DECIMAL_ERROR_MESSAGE = "This is not a valid decimal - try again";
        public const string  EXIT_MESSAGE = "Press any key to exit the calculator";
        public const string  ENTER_SALARY_MESSAGE = "Enter your gross salary:";
        #endregion
    }
}
