using System;

class CarInsuranceApprovalProgram
{
    static void Main()
    {
        // Ask questions to the applicant
        Console.WriteLine("What is your age?");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Have you ever had a DUI? (true/false)");
        bool hasDUI = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("How many speeding tickets do you have?");
        int speedingTickets = Convert.ToInt32(Console.ReadLine());

        // Check qualification rules
        bool isQualified = (age > 15) && !hasDUI && (speedingTickets <= 3);

        // Print the result
        Console.WriteLine("Qualified? " + isQualified);
    }
}