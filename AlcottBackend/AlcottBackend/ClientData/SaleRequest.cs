using AlcottBackend.Models;

namespace AlcottBackend.ClientData;

public class SaleRequest
{
    public decimal AmountPaid { get; set; }
    public byte PaymentMethod { get; set; }

    public required List<IdQuantityPair> SaleDetails { get; set; }
}

