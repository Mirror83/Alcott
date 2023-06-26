using AlcottBackend.Data;
using AlcottBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlcottBackend.Services;

public class ProductService
{
    private readonly DatabaseContext _context;

    public ProductService(DatabaseContext context)
    {
        _context = context;
    }

    public ICollection<Product> GetAll()
    {
        return _context.Products
            .AsNoTracking()
            .ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products
        .AsNoTracking()
        .SingleOrDefault(product => product.Id == id);
    }

    public Product Create(Product newProduct)
    {
        // New product is assumed to be valid
        // Validation must be done manually
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return newProduct;
    }

    public Product? UpdateProductAfterSale(int id, int quantity)
    {
        Product? productToBeSold = _context.Products.Find(id);

        if (productToBeSold is Product)
        {
            var newStockLevel = productToBeSold.StockLevel - quantity;

            if (newStockLevel < 0)
            {
                throw new InvalidOperationException("The quantity ordered exceeds the quantity in stock");
            }

            productToBeSold.StockLevel = newStockLevel;
            _context.SaveChanges();
            return productToBeSold;
        }
        else
        {
            return null;
        }

    }

    public Product? UpdateProductAfterOrder(int id, int quantity)
    {
        Product? productToBeSold = _context.Products.Find(id);

        if (productToBeSold is not null)
        {
            var newStockLevel = productToBeSold.StockLevel + quantity;

            if (newStockLevel < productToBeSold.StockLevel)
            {
                throw new InvalidOperationException("The quantity ordered cannot be negative");
            }

            productToBeSold.StockLevel = newStockLevel;
            _context.SaveChanges();
            return productToBeSold;
        }
        else
        {
            return null;
        }

    }

    // To implement
    public IEnumerable<Product> GetInRange(int start)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        Product? productToBeDeleted = _context.Products.Find(id);

        if (productToBeDeleted is Product)
        {
            _context.Products.Remove(productToBeDeleted);
            _context.SaveChanges();
        }
    }

}