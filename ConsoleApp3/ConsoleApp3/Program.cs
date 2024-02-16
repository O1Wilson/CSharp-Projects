using System;

class PackageExpress
{
    static void Main()
    {
        // Welcome message
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Get package weight from user
        Console.WriteLine("Please enter the package weight:");
        int weight = Convert.ToInt32(Console.ReadLine());

        // Check if weight is greater than 50
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // Get package dimensions from user
        Console.WriteLine("Please enter the package width:");
        int width = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter the package height:");
        int height = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter the package length:");
        int length = Convert.ToInt32(Console.ReadLine());

        // Check if dimensions total is greater than 50
        int dimensionsTotal = width + height + length;
        if (dimensionsTotal > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Calculate quote
        decimal quote = (width * height * length * weight) / 100.0m;

        // Display the quote
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thank you!");
    }
}
