// <copyright file="RoleClaim.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class RoleClaimTypeConfig<TKey> : DotCommerceEntityTypeConfig<RoleClaim<TKey>, int>
  where TKey : IEquatable<TKey>
{
    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<RoleClaim<TKey>> entity)
  {
    base.Configure(entity);
    entity.ToTable("identity_role_claims");
  }
}