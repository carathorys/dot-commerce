using FuryTechs.DotCommerce.Core.Database.Entities.Customer;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.System;

public class CountryTypeConfig<TKey> : MultiLingualDotCommerceEntityTypeConfig<TKey, Country<TKey>, CountryTranslation<TKey>>
  where TKey : IEquatable<TKey>
{
    public override void Configure(EntityTypeBuilder<Country<TKey>> builder)
    {
        base.Configure(builder);
        builder.ToTable("country")
          .HasIndex(x => x.CountryCode).IsUnique();

        builder.HasMany(x => x.Translations).WithOne(x => x.Base).HasForeignKey(x => x.BaseId).IsRequired(true);
    }
}