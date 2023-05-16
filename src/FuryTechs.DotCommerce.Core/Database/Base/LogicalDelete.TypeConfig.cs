// <copyright file="LogicalDelete.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class LogicalDeleteTypeConfig<TEntity> : IEntityTypeConfiguration<TEntity>
  where TEntity : class, ILogicalDelete
{
  /// <summary>
  /// Static method to decorate the entity properly.
  /// This can be used as a standalone <see cref="IEntityTypeConfiguration{TEntity}"/>, can be invoked because it's static.
  /// </summary>
  /// <param name="entity">Entity Type builder instance.</param>
  /// <typeparam name="TBuilder">Type of the builder.</typeparam>
  public static void ConfigILogicalDeleteEntity<TBuilder>(TBuilder entity)
    where TBuilder : EntityTypeBuilder<TEntity>
  {
    entity.Property(x => x.DeletedAt).IsRequired(false);
  }

  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<TEntity> builder)
    => ConfigILogicalDeleteEntity(builder);
}