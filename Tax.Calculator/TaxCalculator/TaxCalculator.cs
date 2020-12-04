using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tax.Calculator.Helpers;
using Tax.Calculator.Helpers.Calculators;
using Tax.Calculator.Helpers.Calculators.Factory;
using Tax.Calculator.Helpers.Common;
using Tax.Calculator.Services.Contracts;

namespace Tax.Calculator
{
    public class TaxCalculator
    {
        private decimal incomeTax;
        private decimal taxableIncome;
        private decimal taxableIncomeForSocialContributions;
        private decimal socialContributions;
        private decimal baseIncome;
        private bool isValidatedDecimal = true;
        private List<Task> simultaneousTasks = new List<Task>();
        private Stopwatch stopwatch = new Stopwatch();
        private Logger logger = new Logger();
        private readonly CalculatorFactory _taxFactory = null;
        private readonly CalculatorFactory _contributionsFactory = null;
        private IBaseIncomeService incomeService = new BaseIncomeService();
       
        public TaxCalculator()
        {
            _taxFactory = new IncomeTaxCalculatorFactory();
            _contributionsFactory = new SocialContributionsCalculatorFactory();
        }

        public void CalculateTaxes(decimal grossSalary = GlobalConstants.DEFAULT_VALUE)
        {
            if (grossSalary == GlobalConstants.DEFAULT_VALUE)
            {
                logger.EnterSalaryMessage();

                isValidatedDecimal = this.GetGrossSalary(out grossSalary);
            }

            stopwatch.Start();

            if (isValidatedDecimal && grossSalary > GlobalConstants.DEFAULT_VALUE)
            {
                if (GlobalConstants.MINIMUM_TAXABLE_INCOME >= grossSalary)
                {
                    baseIncome = grossSalary;
                    logger.NoTaxMessage(grossSalary);
                }
                else
                {
                    CalculateIncomeTax(grossSalary);
                    CalculateSocialContributions(grossSalary);

                    baseIncome = incomeService.GetBaseIncome(grossSalary, incomeTax, socialContributions);
                    stopwatch.Stop();

                    logger.Info($"Taxable income: {taxableIncome}, income tax: {incomeTax}, social contributions {socialContributions}." +
                        $" The task was executed for {stopwatch.Elapsed}");

                    logger.Info($"Base income is: {baseIncome} IDR");

                    logger.ExitMessage();
                }
            }
            else
            {
                logger.InvalidDecimalError();
            }
        }

        public void CalculateTaxesAsync(decimal grossSalary = GlobalConstants.DEFAULT_VALUE)
        {
            if (grossSalary == GlobalConstants.DEFAULT_VALUE)
            {
                logger.EnterSalaryMessage();

                isValidatedDecimal = this.GetGrossSalary(out grossSalary);
            }

            stopwatch.Start();

            if (isValidatedDecimal && grossSalary > GlobalConstants.DEFAULT_VALUE)
            {
                if (GlobalConstants.MINIMUM_TAXABLE_INCOME >= grossSalary)
                {
                    baseIncome = grossSalary;
                    logger.NoTaxMessage(grossSalary);
                }
                else
                {
                    Task calculateIncomeTax = Task.Run(() =>
                    {
                        CalculateIncomeTax(grossSalary);
                    });

                    Task calculateSocialContributions = Task.Run(() =>
                    {
                        CalculateSocialContributions(grossSalary);
                    });

                    simultaneousTasks.Add(calculateIncomeTax);
                    simultaneousTasks.Add(calculateSocialContributions);

                    Task.WaitAll(simultaneousTasks.ToArray());

                    baseIncome = incomeService.GetBaseIncome(grossSalary, incomeTax, socialContributions);
                    stopwatch.Stop();

                    logger.Info($"Taxable income: {taxableIncome}, income tax: {incomeTax}, social contributions {socialContributions}." +
                        $" The task was executed for {stopwatch.Elapsed}");

                    logger.Info($"Base income is: {baseIncome} IDR");

                    logger.ExitMessage();
                }
            }
            else
            {
                logger.InvalidDecimalError();
            }
        }

        public decimal ShowIncomeTax()
        {
            return incomeTax;
        }

        public decimal ShowTaxableIncome()
        {
            return this.taxableIncome;
        }

        public decimal ShowSocialContributions()
        {
            return this.socialContributions;
        }

        public decimal ShowBasicIncome()
        {
            return this.baseIncome;
        }

        private void CalculateSocialContributions(decimal grossSalary)
        {
            taxableIncomeForSocialContributions = incomeService.GetTaxableIncomeForSocialContributions(grossSalary);
            socialContributions = GetSocialContributions(taxableIncomeForSocialContributions);
        }

        private void CalculateIncomeTax(decimal grossSalary)
        {
            taxableIncome = incomeService.GetTaxableIncome(grossSalary);
            incomeTax = GetIncomeTax(taxableIncome);
        }

        private decimal GetSocialContributions(decimal taxableIncomeForSocialContributions)
        {
            var socialContributionsCalculator = _contributionsFactory.GetCalculator();
            decimal socialContributions = socialContributionsCalculator.CalculateTax(taxableIncomeForSocialContributions);
            return socialContributions;
        }

        private decimal GetIncomeTax(decimal taxableIncome)
        {
            var taxCalculator = _taxFactory.GetCalculator();
            decimal incomeTax = taxCalculator.CalculateTax(taxableIncome);
            return incomeTax;
        }

        private bool GetGrossSalary(out decimal grossValue)
        {
            var isDecimal = decimal.TryParse(Console.ReadLine(), out grossValue);
            return isDecimal;
        }
    }
}
