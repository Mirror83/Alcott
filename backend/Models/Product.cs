using System.ComponentModel.DataAnnotations;
namespace AlcottBackend.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public decimal Price { get; set; }
    [Required]
    public string? Category { get; set; }
    public int StockLevel { get; set; }
}