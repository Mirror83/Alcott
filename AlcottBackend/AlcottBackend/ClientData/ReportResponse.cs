namespace AlcottBackend.ClientData;

public class ReportResponse
{
    public int ProductsSold { get; set; }
    public int SalesMade { get; set; }
    public int TotalAmountOnSales { get; set; }
    public int OrdersMade { get; set; }
    public int OrdersReceived { get; set; }
    public int TotalAmountOnOrders { get; set; }
}