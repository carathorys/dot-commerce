using FuryTechs.DotCommerce.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace FuryTechs.DotCommerce.WebAPI;

public class WebDbContext : BaseDbContext
{
  /// <inheritdoc cref="BaseDbContext" />
  public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
  {
  }

  // public DbSet<Customer> Customers { get; set; } = default!;
  // public DbSet<Address> Addresses { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    // builder.Entity<Customer>();
    // builder.Entity<Address>();
  }
}