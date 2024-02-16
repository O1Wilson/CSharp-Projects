using System;

class Program
{
    static void Main()
    {
        // Anonymous Income Comparison Program
        Console.WriteLine("Anonymous Income Comparison Program");

        // Person 1
        Console.WriteLine("Person 1");
        Console.Write("Hourly Rate? ");
        double hourlyRate1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Hours worked per week? ");
        double hoursWorked1 = Convert.ToDouble(Console.ReadLine());

        // Person 2
        Console.WriteLine("Person 2");
        Console.Write("Hourly Rate? ");
        double hourlyRate2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Hours worked per week? ");
        double hoursWorked2 = Convert.ToDouble(Console.ReadLine());

        // Calculate annual salary
        double annualSalary1 = hourlyRate1 * hoursWorked1 * 52;
        double annualSalary2 = hourlyRate2 * hoursWorked2 * 52;

        // Display annual salaries
        Console.WriteLine("Annual salary of Person 1:");
        Console.WriteLine("{0:C}", annualSalary1);

        Console.WriteLine("Annual salary of Person 2:");
        Console.WriteLine("{0:C}", annualSalary2);

        // Compare salaries
        bool comparisonResult = annualSalary1 > annualSalary2;

        // Display the result
        Console.WriteLine("Does Person 1 make more money than Person 2?");
        Console.WriteLine(comparisonResult);
    }
}
