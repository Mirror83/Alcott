using Microsoft.EntityFrameworkCore;
using AlcottBackend.Models;

namespace AlcottBackend.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Product> Products => Set<Product>();
}