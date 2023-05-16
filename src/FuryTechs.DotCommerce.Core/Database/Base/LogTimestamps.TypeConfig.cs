// <copyright file="LogTimestamps.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class LogTimestampsTypeConfig<T> : IEntityTypeConfiguration<T>
  where T : class, ILogTimestamps
{
  /// <summary>
  /// Static method to decorate the entity properly.
  /// This can be used as a standalone <see cref="IEntityTypeConfiguration{TEntity}"/>, can be invoked because it's static.
  /// </summary>
  /// <param name="entity">Entity Type builder instance.</param>
  /// <typeparam name="TBuilder">Type of the builder.</typeparam>
  public static void ConfigLogTimestampsEntityFields<TBuilder>(TBuilder entity)
    where TBuilder : EntityTypeBuilder<T>
  {
    entity.Property(x => x.CreatedAt)
      .ValueGeneratedOnAdd()
      .HasDefaultValueSql("NOW()")
      .ValueGeneratedOnUpdateSometimes();
    entity
      .Property(x => x.UpdatedAt)
      .ValueGeneratedOnAddOrUpdate()
      .HasDefaultValueSql("NOW()")
      .ValueGeneratedOnUpdateSometimes();

    entity.HasIndex(x => x.CreatedAt);
    entity.HasIndex(x => x.UpdatedAt);
  }

  /// <inheritdoc/>
  public virtual void Configure(EntityTypeBuilder<T> entity) =>
    ConfigLogTimestampsEntityFields(entity);
}