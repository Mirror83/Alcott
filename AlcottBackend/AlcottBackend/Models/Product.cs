namespace AlcottBackend.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required int StockLevel { get; set; }
    public decimal Price { get; set; }
}
