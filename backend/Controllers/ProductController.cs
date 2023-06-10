using Microsoft.AspNetCore.Mvc;
using AlcottBackend.Models;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public List<Product> GetProducts()
    {
        return new List<Product> {
            new Product {Id = 1, Name = "Progas 2kg", Category = "Gas", Price = 1200, StockLevel = 10 },
            new Product {Id = 2, Name = "PVC pipe 1m", Category = "Piping", Price = 400, StockLevel = 100}
        };

    }
}