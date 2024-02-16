using System;
using System.Collections.Generic;

class MoneyExpenseApp
{
    static void Main()
    {
        // A one-dimensional array of expense categories
        string[] expenseCategories = { "Groceries", "Entertainment", "Utilities", "Transportation", "Dining Out" };

        // Array to store user input for expenses
        decimal[] expenses = new decimal[expenseCategories.Length];

        // Ask the user to input their expenses for each category
        for (int i = 0; i < expenseCategories.Length; i++)
        {
            Console.Write($"Enter the amount spent on {expenseCategories[i]}: $");
            expenses[i] = Convert.ToDecimal(Console.ReadLine());
        }

        // Display the entered expenses
        Console.WriteLine("\nEntered Expenses:");
        for (int i = 0; i < expenseCategories.Length; i++)
        {
            Console.WriteLine($"{expenseCategories[i]}: ${expenses[i]:F2}");
        }

        // Calculate and display the total expenses
        decimal totalExpenses = 0;
        foreach (decimal expense in expenses)
        {
            totalExpenses += expense;
        }

        Console.WriteLine($"\nTotal Expenses: ${totalExpenses:F2}");

        // A list of strings with at least two identical strings
        List<string> duplicateStringsList = new List<string> { "Money", "Savings", "Investments", "Budgeting", "Money" };

        // Create a foreach loop that evaluates each item in the list
        Console.WriteLine("\nChecking for duplicate strings in the list:");
        HashSet<string> seenStrings = new HashSet<string>();

        foreach (string currentString in duplicateStringsList)
        {
            if (seenStrings.Contains(currentString))
            {
                Console.WriteLine($"'{currentString}' has already appeared in the list.");
            }
            else
            {
                Console.WriteLine($"'{currentString}' is a new entry in the list.");
                seenStrings.Add(currentString);
            }
        }
    }
}
