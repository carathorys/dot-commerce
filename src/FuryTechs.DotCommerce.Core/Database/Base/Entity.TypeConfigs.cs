// <copyright file="Entity.TypeConfigs.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class EntityTypeConfig<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
  where TEntity : class, IEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// Static method to decorate the entity properly.
  /// This can be used as a standalone <see cref="IEntityTypeConfiguration{TEntity}"/>, can be invoked because it's static.
  /// </summary>
  /// <param name="entity">Entity Type builder instance.</param>
  /// <typeparam name="TBuilder">Type of the builder.</typeparam>
  public static void ConfigEntityFields<TBuilder>(TBuilder entity)
    where TBuilder : EntityTypeBuilder<TEntity>
  {
    entity.HasKey(x => x.Id);
  }

  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<TEntity> entity)
    => ConfigEntityFields(entity);
}