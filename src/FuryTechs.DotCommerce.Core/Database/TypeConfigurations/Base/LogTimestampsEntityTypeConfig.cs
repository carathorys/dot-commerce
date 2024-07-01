using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

public abstract class LogTimestampsEntityTypeConfig<TEntity> 
  : IDotCommerceEntityTypeConfig<TEntity>
  where TEntity : class, ILogTimestamps
{
  /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}.Configure"/>
  public virtual void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.Property(x => x.CreatedAt)
      .ValueGeneratedOnAdd()
      .HasDefaultValueSql(sql: "NOW()");

    builder
      .Property(x => x.UpdatedAt)
      .ValueGeneratedOnAddOrUpdate()
      .HasDefaultValueSql(sql: "NOW()");

    builder.HasIndex(x => x.CreatedAt);
    builder.HasIndex(x => x.UpdatedAt);
  }
}