using System;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void SayName()
    {
        Console.WriteLine($"Name: {FirstName} {LastName}");
    }
}

class Employee : Person
{
    public int Id { get; set; }
}

class Program
{
    static void Main()
    {
        Employee employee = new Employee
        {
            FirstName = "Kevin",
            LastName = "Moser",
            Id = 123 
        };

        employee.SayName();

        Console.WriteLine($"Employee Id: {employee.Id}");
    }
}
