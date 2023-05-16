// <copyright file="UserToken.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class UserTokenTypeConfig<TKey> : IEntityTypeConfiguration<UserToken<TKey>>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<UserToken<TKey>> entity)
  {
    entity.ToTable("identity_user_token");

    LogicalDeleteTypeConfig<UserToken<TKey>>.ConfigILogicalDeleteEntity(entity);
    LogTimestampsTypeConfig<UserToken<TKey>>.ConfigLogTimestampsEntityFields(entity);
  }
}