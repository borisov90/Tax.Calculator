using NUnit.Framework;
using Tax.Calculator;
using Tax.Calculator.Helpers.Common;

namespace Tests
{
    public class Tests
    {
        private TaxCalculator _taxCalculator;

        [SetUp]
        public void Setup()
        {
            _taxCalculator = new TaxCalculator();
        }

        [Test]
        public void InputUnder1000IDRShouldHaveZeroTax()
        {
            _taxCalculator.CalculateTaxes(980);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            Assert.IsTrue(incomeTax == GlobalConstants.DEFAULT_VALUE);
        }

        [Test]
        public void InputOf1000IDRShouldHaveZeroTax()
        {
            _taxCalculator.CalculateTaxes(1000);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            Assert.IsTrue(incomeTax == GlobalConstants.DEFAULT_VALUE);
        }

        [Test]
        public void InputOver1000IDRShouldNotBeZero()
        {
            _taxCalculator.CalculateTaxes(1100);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            Assert.IsTrue(incomeTax != GlobalConstants.DEFAULT_VALUE);
        }

        [Test]
        public void InputOver1000IDRShouldBe10PercentOfNetSalary()
        {
            _taxCalculator.CalculateTaxes(1100);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            var tenPercentOfSalary = (((1100 - 1000) * 10) / 100);

            Assert.IsTrue(incomeTax == tenPercentOfSalary);
        }

        [Test]
        public void InputUnder1000ShouldHaveNoContributions()
        {
            _taxCalculator.CalculateTaxes(980);

            var socialContributions = _taxCalculator.ShowSocialContributions();

            Assert.IsTrue(socialContributions == GlobalConstants.DEFAULT_VALUE);
        }

        [Test]
        public void InputBetween1000and3000ShouldHaveContributions()
        {
            _taxCalculator.CalculateTaxes(2000);

            var socialContributions = _taxCalculator.ShowSocialContributions();

            Assert.IsTrue(socialContributions != GlobalConstants.DEFAULT_VALUE);
        }

        [Test]
        public void InputFor3000AndMoreShouldNotBeDifferent()
        {
            _taxCalculator.CalculateTaxes(3000);

            var socialContributionsMax = _taxCalculator.ShowSocialContributions();

            _taxCalculator.CalculateTaxes(20000);

            var socialContributions20000 = _taxCalculator.ShowSocialContributions();

            Assert.IsTrue(socialContributionsMax == socialContributions20000);
        }

        [Test]
        public void TaxesFor980ShouldNotBeDifferentInRegularAndAsyncCalculation()
        {
            _taxCalculator.CalculateTaxes(980);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            _taxCalculator.CalculateTaxesAsync(980);

            var incomeTaxAsync = _taxCalculator.ShowIncomeTax();

            Assert.IsTrue(incomeTax == incomeTaxAsync);
        }

        [Test]
        public void TaxesFor2000ShouldNotBeDifferentInRegularAndAsyncCalculation()
        {
            _taxCalculator.CalculateTaxes(2000);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            _taxCalculator.CalculateTaxesAsync(2000);

            var incomeTaxAsync = _taxCalculator.ShowIncomeTax();

            Assert.IsTrue(incomeTax == incomeTaxAsync);
        }

        [Test]
        public void TaxesFor10000ShouldNotBeDifferentInRegularAndAsyncCalculation()
        {
            _taxCalculator.CalculateTaxes(10000);

            var incomeTax = _taxCalculator.ShowIncomeTax();

            _taxCalculator.CalculateTaxesAsync(10000);

            var incomeTaxAsync = _taxCalculator.ShowIncomeTax();

            Assert.IsTrue(incomeTax == incomeTaxAsync);
        }

        [Test]
        public void ContributionsFor980ShouldNotBeDifferentInRegularAndAsyncCalculation()
        {
            _taxCalculator.CalculateTaxes(980);

            var socialContributions = _taxCalculator.ShowSocialContributions();

            _taxCalculator.CalculateTaxesAsync(980);

            var socialContributionsAsync = _taxCalculator.ShowSocialContributions();

            Assert.IsTrue(socialContributions == socialContributionsAsync);
        }

        [Test]
        public void ContributionsFor4000ShouldNotBeDifferentInRegularAndAsyncCalculation()
        {
            _taxCalculator.CalculateTaxes(4000);

            var socialContributions = _taxCalculator.ShowSocialContributions();

            _taxCalculator.CalculateTaxesAsync(4000);

            var socialContributionsAsync = _taxCalculator.ShowSocialContributions();

            Assert.IsTrue(socialContributions == socialContributionsAsync);
        }

        [Test]
        public void InputUnder1000BasicIncomeShouldBeSameAsGrossIncome()
        {
            _taxCalculator.CalculateTaxes(980);

            var basicIncome = _taxCalculator.ShowBasicIncome();

            Assert.IsTrue(basicIncome == 980);
        }

        [Test]
        public void InputOver1000BasicIncomeShouldBeSmallerThanGrossIncome()
        {
            _taxCalculator.CalculateTaxes(3400);

            var basicIncome = _taxCalculator.ShowBasicIncome();

            Assert.IsTrue(basicIncome < 3400);
        }
    }
}