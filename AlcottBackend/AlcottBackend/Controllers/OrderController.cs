using AlcottBackend.ClientData;
using AlcottBackend.Models;
using AlcottBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlcottBackend.Controllers;

[ApiController]
[Route("api/order")]
[Authorize]
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
        Order? order = _service.GetOrder(id);
        if (order is not null) return Ok(order); else return NotFound();
    }

    [HttpGet]
    public IEnumerable<Order> GetOrders()
    {
        return _service.GetOrders();
    }

    [HttpPost]
    public ActionResult<Order> RecordOrder(OrderRequest orderRequest)
    {
        try
        {
            var newOrder = _service.RecordOrder(orderRequest);
            return Ok(newOrder);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
