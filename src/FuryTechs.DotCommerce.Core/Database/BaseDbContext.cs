using FuryTechs.DotCommerce.Core.Database.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FuryTechs.DotCommerce.Core.Database
{
  public class BaseDbContext : IdentityDbContext<User, Role, Guid>
  {
    public BaseDbContext(DbContextOptions<BaseDbContext> options): base(options)
    {
      
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);

      builder.Entity<User>(entity =>
      {
        entity.ToTable(name: "User");         
      });

      builder.Entity<Role>(entity =>
      {
        entity.ToTable(name: "Role");
      });
      builder.Entity<IdentityUserRole<Guid>>(entity =>
      {
        entity.ToTable("UserRoles");
        entity.HasKey(key => new { key.UserId, key.RoleId });
      });

      builder.Entity<IdentityUserClaim<Guid>>(entity =>
      {
        entity.ToTable("UserClaims");
      });

      builder.Entity<IdentityUserLogin<Guid>>(entity =>
      {
        entity.ToTable("UserLogins");
        entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });       
      });

      builder.Entity<IdentityRoleClaim<Guid>>(entity =>
      {
        entity.ToTable("RoleClaims");

      });

      builder.Entity<IdentityUserToken<Guid>>(entity =>
      {
        entity.ToTable("UserTokens");
        entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
      });
    }
  }
}