using System;

class MethodOverloading
{
    public int Overloading(int num)
    {
        int result = num + 5;
        return result;
    }

    public int Overloading(decimal num)
    {
        int result = Convert.ToInt32(num * 2);
        return result;
    }

    public int Overloading(string numString)
    {
        if (int.TryParse(numString, out int num))
        {
            int result = num * num;
            return result;
        }
        else
        {
            Console.WriteLine("Invalid input. Please provide a valid integer.");
            return 0;
        }
    }
}

class Program
{
    static void Main()
    {
        MethodOverloading mathOps = new MethodOverloading();

        int result1 = mathOps.Overloading(10);
        Console.WriteLine($"Result of integer operation: {result1}");

        int result2 = mathOps.Overloading(7.5m);
        Console.WriteLine($"Result of decimal operation: {result2}");

        int result3 = mathOps.Overloading("15");
        Console.WriteLine($"Result of string-to-integer operation: {result3}");

        int result4 = mathOps.Overloading("InvalidInput");
        Console.ReadLine();
    }
}
