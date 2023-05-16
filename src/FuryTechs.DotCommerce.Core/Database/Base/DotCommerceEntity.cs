// <copyright file="DotCommerceEntity.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Base
{
  using Microsoft.EntityFrameworkCore;

  /// <summary>
  /// An abstraction to handle most common things.
  /// </summary>
  /// <typeparam name="TKey">Key of the entity.</typeparam>
  [EntityTypeConfiguration(typeof(DotCommerceEntityTypeConfig<,>))]
  public abstract class DotCommerceEntity<TKey> : IEntity<TKey>, ILogTimestamps
    where TKey : IEquatable<TKey>
  {
    /// <inheritdoc cref="IEntity{T}.Id"/>
    public TKey Id { get; set; } = default!;

    /// <inheritdoc cref="ILogTimestamps.CreatedAt"/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc cref="ILogTimestamps.UpdatedAt"/>
    public DateTimeOffset UpdatedAt { get; set; }
  }
}