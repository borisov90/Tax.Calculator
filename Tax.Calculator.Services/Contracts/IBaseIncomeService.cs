using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Calculator.Services.Contracts
{
    public interface IBaseIncomeService
    {
        decimal GetTaxableIncome(decimal grossIncome);

        decimal GetTaxableIncomeForSocialContributions(decimal grossIncome);

        decimal GetBaseIncome(decimal grossIncome, decimal taxIncome, decimal socialContributions);
    }
}
