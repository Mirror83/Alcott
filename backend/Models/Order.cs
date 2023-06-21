namespace AlcottBackend.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime ReceivedAt { get; set; } = DateTime.Now;
    public double PricePaid { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; }
}