using System;

namespace ConsoleApp8
{
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
}
