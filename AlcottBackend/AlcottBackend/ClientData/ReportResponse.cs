namespace AlcottBackend.ClientData;

public class ReportResponse
{
    public int ProductsSold { get; set; }
    public int SalesMade { get; set; }
    public decimal TotalAmountOnSales { get; set; }
    public int OrdersReceived { get; set; }
    public int ProductsOrdered { get; set; }
    public decimal TotalAmountOnOrders { get; set; }
}