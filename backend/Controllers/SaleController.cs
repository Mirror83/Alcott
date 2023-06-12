using Microsoft.AspNetCore.Mvc;
using AlcottBackend.Models;
using AlcottBackend.Services;
using AlcottBackend.ClientData;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/sales")]
public class SaleController : ControllerBase
{
    private SaleService _service;

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
    public ActionResult<Sale> RecordSale(ClientSale clientSale)
    {
        try
        {
            var sale = _service.RecordSale(clientSale);
            return CreatedAtAction(nameof(GetSales), sale);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }
}