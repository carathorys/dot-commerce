// <copyright file="Role.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class RoleTypeConfig<TKey> : DotCommerceEntityTypeConfig<Role<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc cref="DotCommerceEntityTypeConfig{T,TKey}" />
  public override void Configure(EntityTypeBuilder<Role<TKey>> entity)
  {
    base.Configure(entity);
    entity.ToTable(name: "identity_role");
  }
}