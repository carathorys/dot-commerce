using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

/// <inheritdoc cref="IdentityUserToken{TKey}"/>
public class UserTokenTypeConfig<TKey> : LogTimestampsEntityTypeConfig<UserToken<TKey>>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<UserToken<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_user_token");
  }
}