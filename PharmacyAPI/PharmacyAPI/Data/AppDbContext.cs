using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }

        public DbSet<Tender> Tenders { get; set; }

        public DbSet<DrugOrder> DrugOrders { get; set; }

 
    }
}
