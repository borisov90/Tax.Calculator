using System;
using System.Collections.Generic;
using System.Text;
using Tax.Calculator.Helpers.Common;

namespace Tax.Calculator.Services.Contracts
{
    public class BaseIncomeService : IBaseIncomeService
    {
        public decimal GetTaxableIncome(decimal grossIncome)
        {
            return grossIncome - GlobalConstants.DEDUCTABLE_INCOME;
        }

        public decimal GetTaxableIncomeForSocialContributions(decimal taxableIncome)
        {
            if (taxableIncome > GlobalConstants.MAXIMUM_TAXABLE_INCOME_FOR_SOCIAL)
            {
                taxableIncome = GlobalConstants.MAXIMUM_TAXABLE_INCOME_FOR_SOCIAL;
            }

            return taxableIncome - GlobalConstants.DEDUCTABLE_INCOME;
        }

        public decimal GetBaseIncome(decimal grossIncome, decimal taxIncome, decimal socialContributions)
        {
            return grossIncome - (taxIncome + socialContributions);
        }
    }
}
