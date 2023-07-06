using AlcottBackend.Data;

namespace AlcottBackend.Services;


public class ReportService
{
    private readonly DatabaseContext _context;

    public ReportService(DatabaseContext context)
    {
        _context = context;
    }




}