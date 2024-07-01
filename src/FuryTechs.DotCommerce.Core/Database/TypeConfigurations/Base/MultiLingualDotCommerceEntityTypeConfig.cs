using FuryTechs.DotCommerce.Core.Database.Entities.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

public abstract class MultiLingualDotCommerceEntityTypeConfig<TKey, TEntity, TEntityTranslation>
  : DotCommerceEntityTypeConfig<TEntity, TKey>
  where TKey : IEquatable<TKey>
  where TEntityTranslation : EntityTranslation<TKey, TEntity>
  where TEntity : MultilLingualObject<TKey, TEntityTranslation, TEntity>, IEntity<TKey>, ILogTimestamps
{
    /// <inheritdoc cref="IEntityTypeConfiguration{TEntity}"/>
    public void Configure(EntityTypeBuilder<TEntity> builder, EntityTypeBuilder<TEntityTranslation> translationBuilder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Translations).WithOne(x => x.Base).HasForeignKey(x => x.BaseId);
    }
}