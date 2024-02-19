using System;

class Program
{
    static void Main()
    {
        DateTime currentDateTime = DateTime.Now;
        Console.WriteLine($"Current Date and Time: {currentDateTime}");

        Console.Write("Enter a number: ");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int hoursToAdd))
        {
            DateTime futureDateTime = currentDateTime.AddHours(hoursToAdd);
            Console.WriteLine($"The time in {hoursToAdd} hours will be: {futureDateTime}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.ReadLine();
    }
}
