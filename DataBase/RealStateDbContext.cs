using Microsoft.EntityFrameworkCore;
using RealStateManager.DataBase.Models;

namespace RealStateManager.DataBase
{
  public class RealStateDbContext : DbContext
  {
    public RealStateDbContext(DbContextOptions<RealStateDbContext> options) : base(options) {}

    public DbSet<Property> Properties { get; set; }
    public DbSet<Payment> Payments { get; set; }
  }
}
