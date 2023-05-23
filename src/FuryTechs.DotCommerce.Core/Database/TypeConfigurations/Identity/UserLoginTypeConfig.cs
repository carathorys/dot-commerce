using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

/// <inheritdoc cref="IdentityUserLogin{TKey}" />
public class UserLoginTypeConfig<TKey> : LogTimestampsEntityTypeConfig<UserLogin<TKey>>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<UserLogin<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_user_login");
  }
}