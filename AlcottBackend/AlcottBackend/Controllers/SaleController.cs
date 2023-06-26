using AlcottBackend.ClientData;
using AlcottBackend.Models;
using Microsoft.AspNetCore.Mvc;
using AlcottBackend.Services;
using Microsoft.AspNetCore.Authorization;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/sales")]
[Authorize]
public class SaleController : ControllerBase
{
    private readonly SaleService _service;

    public SaleController(SaleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Sale> GetSales()
    {
        return _service.GetSales();
    }

    // Remember to add exception-handling
    [HttpPost]
    public ActionResult<Sale> RecordSale(SaleRequest saleRequest)
    {
        try
        {
            var sale = _service.RecordSale(saleRequest);
            return CreatedAtAction(nameof(GetSales), sale);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}

