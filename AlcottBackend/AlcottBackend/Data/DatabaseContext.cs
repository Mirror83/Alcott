using AlcottBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlcottBackend.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<Order> Orders => Set<Order>();

    }
}
