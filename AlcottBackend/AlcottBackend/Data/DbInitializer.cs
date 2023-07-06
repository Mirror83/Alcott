using AlcottBackend.Models;

namespace AlcottBackend.Data;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        if (context.Products.Any())
        {
            return;
        }

        var products = new List<Product> {
            new Product {Id = 1, Name = "Progas 2kg", Category = "Gas", Price = 1200, StockLevel = 10 },
            new Product {Id = 2, Name = "PVC pipe 1m", Category = "Piping", Price = 400, StockLevel = 100}
        };

        var employees = new List<Employee> {
            new Employee {Name = "Joel Zimmerman", PasswordHash = BCrypt.Net.BCrypt.HashPassword("deadmau5"), Role="Employee", Email="joelzimm@example.com"},
            new Employee {Name = "Mario Plumber", PasswordHash = BCrypt.Net.BCrypt.HashPassword("supermario"), Role="Admin", Email="marioandluigi@example.com"}
        };

        context.Products.AddRange(products);
        context.Employees.AddRange(employees);
        context.SaveChanges();
    }
}