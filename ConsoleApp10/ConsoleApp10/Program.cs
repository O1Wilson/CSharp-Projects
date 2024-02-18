using System;

class MethodAssignment
{
    public int PerformOperation(int num1, int num2 = 0)
    {
        int result = num1 + num2;
        return result;
    }
}

class Program
{
    static void Main()
    {
        MethodAssignment methodAssign = new MethodAssignment();

        Console.Write("Enter the first number: ");
        int userInput1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number (press Enter to skip): ");
        string userInput2String = Console.ReadLine();

        int userInput2;
        if (string.IsNullOrEmpty(userInput2String))
        {
            userInput2 = 0;
        }
        else
        {
            userInput2 = int.Parse(userInput2String);
        }

        int result = methodAssign.PerformOperation(userInput1, userInput2);

        Console.WriteLine($"The result of the operation is: {result}");

        Console.ReadLine();
    }
}
