using System;
using System.Collections.Generic;

class Employee<T>
{
    public List<T> Things { get; set; }

    public Employee(List<T> things)
    {
        Things = things;
    }
}

class Program
{
    static void Main()
    {
        Employee<string> stringEmployee = new Employee<string>(new List<string> { "Apple", "Banana", "Cherry" });
        Employee<int> intEmployee = new Employee<int>(new List<int> { 1, 2, 3, 4, 5 });

        Console.WriteLine("String Employee Things:");
        foreach (var thing in stringEmployee.Things)
        {
            Console.WriteLine(thing);
        }

        Console.WriteLine("\nInt Employee Things:");
        foreach (var thing in intEmployee.Things)
        {
            Console.WriteLine(thing);
        }
    }
}
