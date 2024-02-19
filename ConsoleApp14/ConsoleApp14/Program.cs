using System;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public abstract void SayName();
}

public class Employee : Person
{
    public override void SayName()
    {
        Console.WriteLine($"Employee's name is {FirstName} {LastName}");
    }
}

class Program
{
    static void Main()
    {
        Employee employee = new Employee
        {
            FirstName = "George",
            LastName = "Brian"
        };

        employee.SayName();
    }
}
