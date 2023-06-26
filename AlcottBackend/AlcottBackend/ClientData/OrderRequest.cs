using AlcottBackend.Models;

namespace AlcottBackend.ClientData;

public class OrderRequest
{
    public decimal AmountPaid { get; set; }
    public List<IdQuantityPair> OrderDetails { get; set; } = new List<IdQuantityPair>();
}

