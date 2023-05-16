// <copyright file="UserClaim.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class UserClaimTypeConfig<TKey> : DotCommerceEntityTypeConfig<UserClaim<TKey>, int>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public override void Configure(EntityTypeBuilder<UserClaim<TKey>> entity)
  {
    base.Configure(entity);
    entity.ToTable("identity_user_claim");
  }
}