using AlcottBackend.Data;
using AlcottBackend.ClientData;
using AlcottBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlcottBackend.Services;

public class SaleService
{
    private readonly DatabaseContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ProductService _productService;
    private readonly EmployeeService _employeeService;
    public SaleService(
        DatabaseContext context,
        IHttpContextAccessor contextAccessor,
        ProductService productService,
        EmployeeService employeeService
        )
    {
        _context = context;
        _httpContextAccessor = contextAccessor;
        _productService = productService;
        _employeeService = employeeService;
    }

    public Sale RecordSale(SaleRequest saleRequest)
    {
        string employeeName = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.Name)
            ?? throw new NullReferenceException("No name found in HTTP context");

        int employeeId = _employeeService.GetIdFromName(employeeName)
            ?? throw new ArgumentException("Employee not found");

        if (saleRequest.SaleDetails.Count == 0)
            throw new ArgumentException("Sale details must have at least one sale detail");


        var sale = new Sale
        {
            AmountPaid = saleRequest.AmountPaid,
            SaleDetails = new List<SaleDetail>(),
            EmployeeId = employeeId
        };

        foreach (var item in saleRequest.SaleDetails)
        {
            var saleDetail = new SaleDetail();
            Product? product = _productService.GetById(item.Id) ?? throw new NullReferenceException();
            saleDetail.ProductId = product.Id;

            _productService.UpdateProductAfterOrder(saleDetail.ProductId, item.Quantity);

            saleDetail.Quantity = item.Quantity;
            sale.SaleDetails.Add(saleDetail);
        }

        return sale;
    }

    public IEnumerable<Sale> GetSales()
    {
        return _context.Sales
            .AsNoTracking()
            .ToList();
    }

}

