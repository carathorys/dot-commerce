using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

/// <inheritdoc cref="IdentityUserRole{TKey}" />
public class UserRoleTypeConfig<TKey> : LogTimestampsEntityTypeConfig<UserRole<TKey>>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<UserRole<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_user_role");
  }
}