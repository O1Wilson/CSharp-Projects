using System;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public static bool operator ==(Employee emp1, Employee emp2)
    {
        if (ReferenceEquals(emp1, emp2))
            return true;

        if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
            return false;

        return emp1.Id == emp2.Id;
    }

    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Employee otherEmployee = (Employee)obj;
        return Id == otherEmployee.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee { Id = 1, Name = "John Doe" };
        Employee emp2 = new Employee { Id = 1, Name = "Jane Doe" };
        Employee emp3 = new Employee { Id = 2, Name = "Bob Smith" };

        Console.WriteLine("emp1 == emp2: " + (emp1 == emp2));
        Console.WriteLine("emp1 == emp3: " + (emp1 == emp3));

        Console.WriteLine("emp1 != emp2: " + (emp1 != emp2));
        Console.WriteLine("emp1 != emp3: " + (emp1 != emp3));
    }
}
