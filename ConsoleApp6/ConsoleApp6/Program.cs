using System;
using System.Collections.Generic;

class MoneyExpenseApp
{
    static void Main()
    {
        string[] expenseCategories = { "Groceries", "Entertainment", "Utilities" };

        // Array to store user input for expenses
        decimal[] expenses = new decimal[expenseCategories.Length];

        // Ask the user to input their expenses for each category
        int i = 0; // Initializing i outside the loop
        while (i <= expenseCategories.Length - 1)
        {
            Console.Write($"Enter the amount spent on {expenseCategories[i]}: $");
            expenses[i] = Convert.ToDecimal(Console.ReadLine());
            i++; // Incrementing i inside the loop
        }

        // Display the entered expenses
        Console.WriteLine("\nEntered Expenses:");
        for (int j = 0; j <= expenseCategories.Length - 1; j++)
        {
            Console.WriteLine($"{expenseCategories[j]}: ${expenses[j]:F2}");
        }

        // Calculate and display the total expenses
        decimal totalExpenses = 0;
        foreach (decimal expense in expenses)
        {
            totalExpenses += expense;
        }

        Console.WriteLine($"\nTotal Expenses: ${totalExpenses:F2}");

        List<string> stringsList = new List<string> { "Money", "Savings", "Investments", "Budgeting" };

        Console.Write("Enter text to search for: ");
        string searchText1 = Console.ReadLine();

        bool found1 = false;

        for (int k = 0; k < stringsList.Count; k++)
        {
            if (stringsList[k].Contains(searchText1))
            {
                Console.WriteLine($"Match found at index {k}");
                found1 = true;
                break; // Stop the loop once a match is found
            }
        }

        if (!found1)
        {
            Console.WriteLine("Text not found in the list.");
        }

        List<string> mStringsList = new List<string> { "Money", "Savings", "Investments", "Budgeting", "Money" };

        // Ask the user to select text to search for in the list
        Console.Write("Enter text to search for: ");
        string searchText2 = Console.ReadLine();

        bool found2 = false;

        // Loop to iterate through the list and display indices of matching text
        Console.WriteLine("Indices of matching text:");
        for (int l = 0; l < mStringsList.Count; l++)
        {
            if (mStringsList[l].Equals(searchText2))
            {
                Console.WriteLine($"Match found at index {l}");
                found2 = true;
            }
        }

        if (!found2)
        {
            Console.WriteLine("Text not found in the list.");
        }

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
