using Microsoft.EntityFrameworkCore;
using SportsStoreApp.Models.Entities;

namespace SportsStoreApp.Models
{
  public class SportsStoreDbContext: DbContext
  {
    public SportsStoreDbContext(DbContextOptions<SportsStoreDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

  }
}
