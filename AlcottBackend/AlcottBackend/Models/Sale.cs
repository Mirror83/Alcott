namespace AlcottBackend.Models;

public class Sale
{
    public int Id { get; set; }
    public decimal AmountPaid { get; set; }

    public byte PaymentMethod { get; set; } = 0; // O for cash, 1 for cashless
    public int EmployeeId { get; set; }

    // Navigation properties
    public ICollection<SaleDetail>? SaleDetails { get; set; }
    public Employee? Employee { get; set; }

}
