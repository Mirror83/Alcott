using System.ComponentModel.DataAnnotations;

namespace AlcottBackend.Models;

public class Sale
{
    public int Id { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime Time { get; set; } = DateTime.Now;
    // A number less than 1 but greater than or equal to 0 representing the percentage
    // that a sale was given
    public decimal DiscountPercentage { get; set; } = 0;

    [Required]
    public string? PaymentType { get; set; } = "Cash";
    public ICollection<SaleDetail>? SaleDetails { get; set; }

}