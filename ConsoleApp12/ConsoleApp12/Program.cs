using System;

public class ClassAssignment
{
    public void DivideByTwo(int input)
    {
        int result = input / 2;
        Console.WriteLine($"Dividing {input} by 2: {result}");
    }

    public void MultiplyAndDivide(int x, int y, out int product, out int quotient)
    {
        product = x * y;
        quotient = x / y;
    }

    public void MultiplyAndDivide(int x, int y)
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
        ClassAssignment classAssignment = new ClassAssignment();

        Console.Write("Enter a number: ");
        int userInput = Convert.ToInt32(Console.ReadLine());

        classAssignment.DivideByTwo(userInput);

        classAssignment.MultiplyAndDivide(userInput, 3, out int product, out int quotient);
        Console.WriteLine($"Product: {product}, Quotient: {quotient}");

        classAssignment.MultiplyAndDivide(userInput, 2);
    }
}
