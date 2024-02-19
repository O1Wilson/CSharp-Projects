using System;

class Program
{
    enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter the current day of the week: ");
            string userInput = Console.ReadLine();

            DaysOfWeek currentDay = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), userInput, true);

            Console.WriteLine($"You entered: {currentDay}");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Please enter an actual day of the week.");
        }
    }
}
