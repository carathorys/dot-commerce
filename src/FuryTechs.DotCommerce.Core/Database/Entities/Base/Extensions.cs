// <copyright file="Extensions.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Entities.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Extensions to EntityTypeBuilder.
/// </summary>
public static class Extensions
{
  private static EntityTypeBuilder<TEntity> ConfigLogTimestampsEntityFields<TEntity>(
    this EntityTypeBuilder<TEntity> entity)
    where TEntity : class, ILogTimestamps
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
    return entity!;
  }

  private static EntityTypeBuilder<TEntity> ConfigIEntity<TEntity, TKey>(
    this EntityTypeBuilder<TEntity> entity
  )
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
  {
    entity.HasKey(x => x.Id);
    return entity;
  }


  /// <summary>
  /// Extension method on EntityTypeBuilder.
  /// </summary>
  /// <param name="entity">Entity Type builder instance.</param>
  /// <param name="tableName">If you would override the table's name, you can provide it's value here.</param>
  /// <typeparam name="TEntity">Type of the entity.</typeparam>
  /// <typeparam name="TKey">Type of the primary key.</typeparam>
  /// <returns>Updated entity type builder.</returns>
  public static EntityTypeBuilder<TEntity> SetupEntity<TEntity, TKey>(
    this EntityTypeBuilder<TEntity> entity,
    string? tableName = null
  )
    where TEntity : class
    where TKey : IEquatable<TKey>
  {
    if (!string.IsNullOrWhiteSpace(tableName))
    {
      entity.ToTable(tableName);
    }

    if (typeof(TEntity).GetInterfaces().Any(x => x == typeof(IEntity<>)))
    {
      (entity as EntityTypeBuilder<IEntity<TKey>>)?.ConfigIEntity<IEntity<TKey>, TKey>();
    }

    if (typeof(TEntity).GetInterfaces().Any(x => x == typeof(ILogTimestamps)))
    {
      (entity as EntityTypeBuilder<ILogTimestamps>)?.ConfigLogTimestampsEntityFields();
    }

    return entity;
  }
}