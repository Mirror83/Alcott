namespace AlcottBackend.Models;

/*
A SaleDetail contains information about a Product that is included in a Sale
A Sale consists of many such SaleDetails, which denote the product that was sold 
as well as the quantity it was (or is to be) sold in

The SaleId and ProductId properties, even though they will be included into the database
by EF Core, are present in this class definition.

They are easier to work with than including whole objects (for Sale and Product)
when data is being sent from the client
*/
public class SaleDetail
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public Sale? Sale { get; set; }
    public ICollection<Product>? Products { get; set; }
}