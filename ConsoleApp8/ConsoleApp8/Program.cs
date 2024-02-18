using System;

class MathOperations
{
    static void Main()
    {
        int inputNumber = 5;

        int result1 = Square(inputNumber);
        int result2 = Double(inputNumber);
        int result3 = AddTen(inputNumber);

        Console.WriteLine($"Square: {result1}");
        Console.WriteLine($"Quintuple: {result2}");
        Console.WriteLine($"Twenty: {result3}");
    }

    static int Square(int number)
    {
        return number * number;
    }

    static int Double(int number)
    {
        return number * 5;
    }

    static int AddTen(int number)
    {
        return number + 20;
    }
}