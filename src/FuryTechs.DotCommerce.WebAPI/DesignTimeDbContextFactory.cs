using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FuryTechs.DotCommerce.WebAPI;

/// <summary>
/// Design-time factory for <see cref="WebDbContext"/>.
/// Used by EF Core CLI tools (dotnet ef migrations) to create the DbContext
/// without requiring the full application host to be running.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebDbContext>
{
    /// <inheritdoc />
    public WebDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WebDbContext>();

        // Use a dummy connection string for design-time operations (migration scaffolding).
        // This connection is never actually opened during migration generation.
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=dot-commerce;Username=dot_commerce;Password=dot_commerce",
            b => b.MigrationsAssembly(typeof(WebDbContext).Assembly.FullName));

        return new WebDbContext(optionsBuilder.Options);
    }
}
