// <copyright file="UserRole.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class UserRoleTypeConfig<TKey> : IEntityTypeConfiguration<UserRole<TKey>>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<UserRole<TKey>> entity)
  {
    entity.ToTable("identity_user_role");

    LogicalDeleteTypeConfig<UserRole<TKey>>.ConfigILogicalDeleteEntity(entity);
    LogTimestampsTypeConfig<UserRole<TKey>>.ConfigLogTimestampsEntityFields(entity);
  }
}