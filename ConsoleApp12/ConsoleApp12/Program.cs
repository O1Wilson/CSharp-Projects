using System;

public static class ClassAssignment
{
    public static void DivideByTwo(int input)
    {
        int result = input / 2;
        Console.WriteLine($"Dividing {input} by 2: {result}");
    }

    public static void MultiplyAndDivide(int x, int y, out int product, out int quotient)
    {
        product = x * y;
        quotient = x / y;
    }

    public static void MultiplyAndDivide(int x, int y)
    {
        int product = x * y;
        int quotient = x / y;
        Console.WriteLine($"Product: {product}, Quotient: {quotient}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int userInput = Convert.ToInt32(Console.ReadLine());

        ClassAssignment.DivideByTwo(userInput);

        ClassAssignment.MultiplyAndDivide(userInput, 3, out int product, out int quotient);
        Console.WriteLine($"Product: {product}, Quotient: {quotient}");

        ClassAssignment.MultiplyAndDivide(userInput, 2);
    }
}
