using System;

class MethodClassAssignment
{
    public void PerformOperation(int num1, int num2)
    {
        int result = num1 * 2;
        Console.WriteLine($"Result of the operation on {num1}: {result}");
        Console.WriteLine($"Second integer: {num2}");
    }
}

class Program
{
    static void Main()
    {
        MethodClassAssignment methodAssign = new MethodClassAssignment();

        Console.WriteLine("Calling the method with two numbers:");
        methodAssign.PerformOperation(5, 10);
        Console.WriteLine();

        Console.WriteLine("Calling the method with named parameters:");
        methodAssign.PerformOperation(num1: 8, num2: 15);

        Console.ReadLine();
    }
}
