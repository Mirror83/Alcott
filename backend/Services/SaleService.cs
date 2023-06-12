using AlcottBackend.Data;
using AlcottBackend.Models;
using AlcottBackend.ClientData;
using Microsoft.EntityFrameworkCore;

namespace AlcottBackend.Services;

public class SaleService
{
    private DatabaseContext _context;
    private ProductService _productService;

    public SaleService(DatabaseContext context, ProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    public IEnumerable<Sale> GetSales()
    {
        return _context.Sales
        .Include(sale => sale.SaleDetails)
        .AsNoTracking()
        .ToList();
    }

    public Sale RecordSale(ClientSale clientSale)
    {
        var sale = new Sale();
        sale.AmountPaid = clientSale.AmountPaid;
        sale.DiscountPercentage = clientSale.DiscountPercentage;
        sale.PaymentType = clientSale.PaymentType;
        sale.SaleDetails = new List<SaleDetail>();

        if (clientSale.saleDetails.Count == 0)
        {
            throw new ArgumentException("Sale details must have at least one sale detail");
        }

        foreach (var IdQuantityPair in clientSale.saleDetails)
        {
            var saleDetail = new SaleDetail();
            Product? product = _productService.GetById(IdQuantityPair.Id);

            if (product is null) throw new NullReferenceException();

            saleDetail.ProductId = product.Id;

            _productService.UpdateProductAfterSale(saleDetail.ProductId, IdQuantityPair.Quantity);

            saleDetail.Quantity = IdQuantityPair.Quantity;
            sale.SaleDetails.Add(saleDetail);
        }

        _context.Sales.Add(sale);
        _context.SaveChanges();

        return sale;
    }


}