using System;
using System.Diagnostics;
using Tax.Calculator.Helpers;

namespace Tax.Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            TaxCalculator calculator = new TaxCalculator();
            calculator.CalculateTaxesAsync();
            Console.ReadKey();
        }
    }
}
