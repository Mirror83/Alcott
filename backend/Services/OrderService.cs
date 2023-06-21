using AlcottBackend.Models;
using AlcottBackend.Data;
using AlcottBackend.ClientData;
using Microsoft.EntityFrameworkCore;

namespace AlcottBackend.Services;

public class OrderService
{
    private readonly DatabaseContext _context;
    private readonly ProductService _productService;

    public OrderService(DatabaseContext context, ProductService productService)
    {
        _context = context;
        _productService = productService;
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

    public Order RecordOrder(ClientOrder clientOrder)
    {
        var order = new Order();
        // TODO: Revert the Order model's type for PricePaid to decimal
        //       Also rename it to AmountPaid for consistency 
        order.PricePaid = (double)clientOrder.AmountPaid;
        order.OrderDetails = new List<OrderDetail>();

        if (clientOrder.orderDetails.Count == 0)
        {
            throw new ArgumentException("Order details must have at least one order detail");
        }

        foreach (var idQuantityPair in clientOrder.orderDetails)
        {
            var orderDetail = new OrderDetail();
            Product? product = _productService.GetById(idQuantityPair.Id);

            if (product is null) throw new NullReferenceException();

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