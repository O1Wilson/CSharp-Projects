using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("The Tech Academy");
        Console.WriteLine("Student Daily Report");

        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        Console.Write("What course are you on? ");
        string course = Console.ReadLine();

        Console.Write("What page number? ");
        int pageNumber = int.Parse(Console.ReadLine());

        Console.Write("Do you need help with anything? Please answer 'true' or 'false': ");
        bool needHelp = bool.Parse(Console.ReadLine());

        Console.Write("Were there any positive experiences you’d like to share? Please give specifics: ");
        string positiveExperiences = Console.ReadLine();

        Console.Write("Is there any other feedback you’d like to provide? Please be specific: ");
        string otherFeedback = Console.ReadLine();

        Console.Write("How many hours did you study today? ");
        double studyHours = double.Parse(Console.ReadLine());

        Console.WriteLine("\nThank you for your answers. An Instructor will respond to this shortly. Have a great day!");
    }
}
