using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Identity;

/// <inheritdoc cref="IdentityUserClaim{TKey}" />
public class UserClaimTypeConfig<TKey> : DotCommerceEntityTypeConfig<UserClaim<TKey>, int>
  where TKey : IEquatable<TKey>
{
  public override void Configure(EntityTypeBuilder<UserClaim<TKey>> builder)
  {
    base.Configure(builder);
    builder.ToTable("identity_user_claim");
  }
}