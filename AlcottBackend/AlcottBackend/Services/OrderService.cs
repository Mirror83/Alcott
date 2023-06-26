using AlcottBackend.Models;
using AlcottBackend.Data;
using AlcottBackend.ClientData;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlcottBackend.Services;

public class OrderService
{
    private readonly DatabaseContext _context;
    private readonly ProductService _productService;
    private readonly EmployeeService _employeeService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(DatabaseContext context, 
        ProductService productService,
        IHttpContextAccessor httpContextAccessor,
        EmployeeService employeeService)
    {
        _context = context;
        _productService = productService;
        _httpContextAccessor = httpContextAccessor;
        _employeeService = employeeService; 
    }

    public IEnumerable<Order> GetOrders()
    {
        return _context.Orders
        .AsNoTracking()
        .ToList();
    }

    public Order? GetOrder(int id)
    {
        return _context.Orders.FirstOrDefault(order => order.Id == id);
    }

    public Order RecordOrder(OrderRequest orderRequest)
    {
        string employeeName = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Name)
            ?? throw new NullReferenceException("No name found in HTTP context");

        int employeeId = _employeeService.GetIdFromName(employeeName)
            ?? throw new ArgumentException("Employee not found");

        var order = new Order
        {
            AmountPaid = orderRequest.AmountPaid,
            OrderDetails = new List<OrderDetail>(),
            EmployeeId = employeeId
        };

        if (orderRequest.OrderDetails.Count == 0)
        {
            throw new ArgumentException("Order details must have at least one order detail");
        }

        foreach (var idQuantityPair in orderRequest.OrderDetails)
        {
            var orderDetail = new OrderDetail();
            Product? product = _productService.GetById(idQuantityPair.Id) ?? throw new NullReferenceException();
            orderDetail.ProductId = product.Id;

            _productService.UpdateProductAfterOrder(orderDetail.ProductId, idQuantityPair.Quantity);

            orderDetail.Quantity = idQuantityPair.Quantity;
            order.OrderDetails.Add(orderDetail);
        }

        _context.Orders.Add(order);
        _context.SaveChanges();

        return order;
    }

}