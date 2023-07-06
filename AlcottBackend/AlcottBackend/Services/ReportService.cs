using AlcottBackend.ClientData;
using AlcottBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace AlcottBackend.Services;


public class ReportService
{
    private readonly DatabaseContext _context;

    public ReportService(DatabaseContext context)
    {
        _context = context;
    }

    public ReportResponse GetDailyReport()
    {
        var todaySales = _context.Sales
        .AsNoTracking()
        .Where(
            sale => sale.RecordedAt.Date == DateTime.Today.Date
        )
        .Include(sale => sale.SaleDetails)
        .ToList();

        int productsSold = 0;

        var totalAmountOnSales = todaySales.Sum(sale => sale.AmountPaid);

        var todayOrders = _context.Orders
        .AsNoTracking()
        .Where(
            order => order.ReceivedAt.Date == DateTime.Today.Date
        ).Include(order => order.OrderDetails)
        .ToList();

        int productsOrdered = 0;

        todayOrders.ForEach(order =>
        {
            Console.WriteLine(order.OrderDetails);
            productsOrdered += order!.OrderDetails!.Count();
        });

        var totalAmountOnOrders = todayOrders.Sum(order => order.AmountPaid);


        return new ReportResponse
        {
            ProductsSold = productsSold,
            SalesMade = todaySales.Count(),
            TotalAmountOnSales = totalAmountOnSales,
            OrdersReceived = todayOrders.Count(),
            ProductsOrdered = productsOrdered,
            TotalAmountOnOrders = totalAmountOnOrders
        };


    }




}