# Tax.Calculator

Tax Calculator project

In the project's Main method there is an instance of the TaxCalculator class that handles the calculations and the output of the results.

The TaxCalculator class itself manages the calculation of the taxes by using internal CalculatorFactory that manages the calculator creation and settings for the different calculations. The TaxCalculator exposes some of the variables that it manages through public getters that show their values (mainly for unit testing purposes). The project contains a UnitTests project, Helper files (including Logger, Abstract Factory, Interfaces, Common constants).

As a console application the user input is taken from the user by the console, but you can also pass values through the CalculateTaxes method (Check the unit tests for reference). This method also has an Async version in case there are more time consuming calculations in the future.
