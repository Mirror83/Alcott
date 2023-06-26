using AlcottBackend.Models;
using AlcottBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;
    public ProductController(ProductService service)
    {
        _service = service;
    }
    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return _service.GetAll();

    }

    [HttpPost]
    public ActionResult<Product> AddProduct(Product newProduct)
    {
        _service.Create(newProduct);

        return CreatedAtAction(nameof(GetProducts), newProduct);
    }
}
