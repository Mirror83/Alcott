using AlcottBackend.Models;
using Microsoft.AspNetCore.Mvc;

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

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}