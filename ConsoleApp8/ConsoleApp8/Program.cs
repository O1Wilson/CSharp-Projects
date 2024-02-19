using System;

class MathOperations
{
    static void Main()
    {
        int inputNumber = 5;

        int result1 = Program.Square(inputNumber);
        int result2 = Program.Double(inputNumber);
        int result3 = Program.AddTwenty(inputNumber);

        Console.WriteLine($"Square: {result1}");
        Console.WriteLine($"Quintuple: {result2}");
        Console.WriteLine($"Twenty: {result3}");
    }
}

class Program
{
    public static int Square(int number)
    {
        return number * number;
    }

    public static int Double(int number)
    {
        return number * 5;
    }

    public static int AddTwenty(int number)
    {
        return number + 20;
    }
}
