// <copyright file="DotCommerceEntity.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public abstract class DotCommerceEntityTypeConfig<T, TKey> : IEntityTypeConfiguration<T>
  where T : class, IEntity<TKey>, ILogTimestamps
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public virtual void Configure(EntityTypeBuilder<T> entity)
  {
    EntityTypeConfig<T, TKey>.ConfigEntityFields(entity);
    LogTimestampsTypeConfig<T>.ConfigLogTimestampsEntityFields(entity);
  }
}