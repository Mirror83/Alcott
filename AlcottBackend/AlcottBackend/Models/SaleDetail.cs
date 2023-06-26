using System.Text.Json.Serialization;

namespace AlcottBackend.Models;

public class SaleDetail
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    // Navigation properties
    [JsonIgnore]
    public Sale? Sale { get; set; }
    [JsonIgnore]
    public Product? Product { get; set; }
}
