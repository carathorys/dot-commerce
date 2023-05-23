using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

/// <inheritdoc cref="IdentityUser{TKey}"/>
public class UserTypeConfig<TKey> : DotCommerceEntityTypeConfig<User<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<User<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_user");
  }
}