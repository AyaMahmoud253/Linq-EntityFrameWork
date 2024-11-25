using linq;

public class Program
{
    public static void Main()
    {
        // Sample data
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Aya", Department = "HR", Salary = 5000 },
            new Employee { Id = 2, Name = "Ahmed", Department = "IT", Salary = 7000 },
            new Employee { Id = 3, Name = "Mona", Department = "Finance", Salary = 6000 },
            new Employee { Id = 4, Name = "Sara", Department = "IT", Salary = 8000 },
            new Employee { Id = 5, Name = "Khaled", Department = "HR", Salary = 4500 },
        };

        // Task 1: Find all employees in the IT department
        Console.WriteLine("Employees in the IT Department:");
        var itEmployees = employees.Where(e => e.Department == "IT");
        foreach (var emp in itEmployees)
        {
            Console.WriteLine(emp.Name);
        }
        Console.WriteLine();

        // Task 2: Get the names of employees who earn more than 6000
        Console.WriteLine("Employees earning more than 6000:");
        var highEarners = employees.Where(e => e.Salary > 6000).Select(e => e.Name);
        foreach (var name in highEarners)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        // Task 3: Order employees by salary in descending order
        Console.WriteLine("Employees ordered by salary (descending):");
        var orderedEmployees = employees.OrderByDescending(e => e.Salary);
        foreach (var emp in orderedEmployees)
        {
            Console.WriteLine($"{emp.Name}: {emp.Salary}");
        }
        Console.WriteLine();

        // Task 4: Group employees by department and count them
        Console.WriteLine("Employees grouped by department:");
        var departmentGroups = employees.GroupBy(e => e.Department)
                                        .Select(g => new { Department = g.Key, Count = g.Count() });
        foreach (var group in departmentGroups)
        {
            Console.WriteLine($"{group.Department}: {group.Count}");
        }
        Console.WriteLine();

        // Task 5: Find the highest salary in the list
        Console.WriteLine("Highest Salary:");
        var highestSalary = employees.Max(e => e.Salary);
        Console.WriteLine(highestSalary);
        Console.WriteLine();

        // Task 6: Check if any employee earns less than 5000
        Console.WriteLine("Check if any employee earns less than 5000:");
        var hasLowEarner = employees.Any(e => e.Salary < 5000);
        Console.WriteLine(hasLowEarner ? "There are low earners." : "No low earners.");
        Console.WriteLine();

        // Task 7: Create a new list containing employees with a salary increased by 10%
        Console.WriteLine("Employees with a 10% salary increase:");
        var updatedSalaries = employees.Select(e => new Employee
        {
            Id = e.Id,
            Name = e.Name,
            Department = e.Department,
            Salary = e.Salary * 1.10m
        });
        foreach (var emp in updatedSalaries)
        {
            Console.WriteLine($"{emp.Name}: {emp.Salary}");
        }
    }
}