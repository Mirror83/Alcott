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
        var todaySales = _context.Sales.AsNoTracking().Where(
            sale => sale.RecordedAt.Date == DateTime.Today.Date
        ).ToList();

        int productsSold = 0;
        todaySales.ForEach(sale => productsSold += sale!.SaleDetails!.Count());

        var totalAmountOnSales = todaySales.Sum(sale => sale.AmountPaid);

        var todayOrders = _context.Orders.AsNoTracking().Where(
            order => order.ReceivedAt.Date == DateTime.Today.Date
        ).ToList();

        int productsOrdered = 0;
        todayOrders.ForEach(order => productsOrdered += order!.OrderDetails!.Count());

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