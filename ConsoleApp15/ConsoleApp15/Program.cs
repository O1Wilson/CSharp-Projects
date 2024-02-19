using System;

public interface IQuittable
{
    void Quit();
}

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public abstract void SayName();
}

public class Employee : Person, IQuittable
{
    public override void SayName()
    {
        Console.WriteLine($"Employee's name is {FirstName} {LastName}");
    }

    public void Quit()
    {
        Console.WriteLine($"{FirstName} {LastName} has quit the job.");
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

        IQuittable quittableEmployee = new Employee
        {
            FirstName = "George",
            LastName = "Brian"
        };

        employee.SayName();
        employee.Quit();

        quittableEmployee.Quit();
    }
}
