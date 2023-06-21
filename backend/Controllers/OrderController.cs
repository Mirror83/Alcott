using Microsoft.AspNetCore.Mvc;
using AlcottBackend.Services;
using AlcottBackend.Models;
using AlcottBackend.ClientData;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _service;
    public OrderController(OrderService orderService)
    {
        _service = orderService;
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _service.GetOrder(id);
        if (order is not null) return Ok(order); else return NotFound();
    }

    [HttpGet]
    public IEnumerable<Order> GetOrders()
    {
        return _service.GetOrders();
    }

    [HttpPost]
    public ActionResult<Order> RecordOrder(ClientOrder clientOrder)
    {
        try
        {
            var newOrder = _service.RecordOrder(clientOrder);
            return Ok(newOrder);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

}