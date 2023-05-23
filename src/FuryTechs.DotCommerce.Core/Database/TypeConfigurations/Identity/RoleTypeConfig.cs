using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

/// <inheritdoc cref="IdentityRole{TKey}"/>
public class RoleTypeConfig<TKey> : DotCommerceEntityTypeConfig<Role<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<Role<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_role");
  }
}