using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

public abstract class DotCommerceEntityTypeConfig<TEntity, TKey>
  : LogTimestampsEntityTypeConfig<TEntity>, IDotCommerceEntityTypeConfig<TEntity>
  where TEntity : class, IEntity<TKey>, ILogTimestamps
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}"/>
  public override void Configure(EntityTypeBuilder<TEntity> builder)
  {
    base.Configure(builder);
    builder.HasKey(x => x.Id);
  }
}