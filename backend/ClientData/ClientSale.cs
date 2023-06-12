namespace AlcottBackend.ClientData;

public class ClientSale
{
    public decimal AmountPaid { get; set; }
    public List<IdQuantityPair> saleDetails { get; set; } = new List<IdQuantityPair>();
    public decimal DiscountPercentage { get; set; } = 0;
    public string PaymentType { get; set; } = "Cash";
}

public struct IdQuantityPair
{
    public int Id { get; set; }
    public int Quantity { get; set; }
}