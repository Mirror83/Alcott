using Microsoft.AspNetCore.Mvc;
using AlcottBackend.Services;
using AlcottBackend.Models;
using AlcottBackend.ClientData;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private OrderService _service;
    public OrderController(OrderService orderService)
    {
        _service = orderService;
    }

    [HttpGet]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _service.GetOrder(id);
        if (order is not null) return Ok(order); else return NotFound();
    }

    public IEnumerable<Order> GetOrders()
    {
        return _service.GetOrders();
    }

    public ActionResult<Order> RecordOrder(ClientOrder clientOrder)
    {
        var newOrder = _service.RecordOrder(clientOrder);
        return CreatedAtAction(nameof(GetOrder), newOrder);
    }

}