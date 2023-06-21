using System.Text.Json.Serialization;

namespace AlcottBackend.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public Product? Product { get; set; }
    [JsonIgnore]
    public Order? Order { get; set; }
    [JsonIgnore]
    public ICollection<OrderDetail>? Orders { get; set; }
}