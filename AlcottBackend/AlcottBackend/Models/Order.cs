namespace AlcottBackend.Models;

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime ReceivedAt { get; set; } = DateTime.Now;
    public decimal AmountPaid { get; set; }
    // Navigation properties
    public ICollection<OrderDetail>? OrderDetails { get; set; }
    public Employee? Employee { get; set; }
    
}