using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" },
            new Employee { Id = 3, FirstName = "Joe", LastName = "Johnson" },
            new Employee { Id = 4, FirstName = "Alice", LastName = "Jones" },
            new Employee { Id = 5, FirstName = "Bob", LastName = "Brown" },
            new Employee { Id = 6, FirstName = "Joe", LastName = "Davis" },
            new Employee { Id = 7, FirstName = "Eva", LastName = "Evans" },
            new Employee { Id = 8, FirstName = "Charlie", LastName = "Chaplin" },
            new Employee { Id = 9, FirstName = "Frank", LastName = "Fisher" },
            new Employee { Id = 10, FirstName = "Grace", LastName = "Green" }
        };

        List<Employee> joesListForeach = new List<Employee>();
        foreach (var employee in employees)
        {
            if (employee.FirstName == "Joe")
            {
                joesListForeach.Add(employee);
            }
        }

        Console.WriteLine("Employees with the first name 'Joe' (using foreach loop):");
        DisplayEmployees(joesListForeach);

        List<Employee> joesListLambda = employees.Where(e => e.FirstName == "Joe").ToList();

        Console.WriteLine("\nEmployees with the first name 'Joe' (using lambda expression):");
        DisplayEmployees(joesListLambda);

        List<Employee> idGreaterThan5List = employees.Where(e => e.Id > 5).ToList();

        Console.WriteLine("\nEmployees with Id greater than 5 (using lambda expression):");
        DisplayEmployees(idGreaterThan5List);
    }

    static void DisplayEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.FirstName} {employee.LastName}");
        }
    }
}

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
