namespace AlcottBackend.ClientData;

public class ClientOrder
{
    public decimal AmountPaid { get; set; }
    public List<IdQuantityPair> orderDetails { get; set; } = new List<IdQuantityPair>();
}