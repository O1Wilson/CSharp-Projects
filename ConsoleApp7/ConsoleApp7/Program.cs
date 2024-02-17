using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };

        try
        {
            Console.Write("Enter a number to divide each element in the list by: ");
            string userInput = Console.ReadLine();

            int divisor = int.Parse(userInput);

            for (int i = 0; i < numbers.Count; i++)
            {
                int result = numbers[i] / divisor;
                Console.WriteLine($"Result of {numbers[i]} divided by {divisor}: {result}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid integer.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Program execution continued after try/catch block.");
        }
    }
}