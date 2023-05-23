using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

public class RoleClaimTypeConfig<TKey> : DotCommerceEntityTypeConfig<RoleClaim<TKey>, int>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<RoleClaim<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_role_claim");
  }
}