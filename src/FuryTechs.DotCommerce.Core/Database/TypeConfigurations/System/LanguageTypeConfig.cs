using FuryTechs.DotCommerce.Core.Database.Entities.System;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.System;

public class LanguageTypeConfig<TKey> : DotCommerceEntityTypeConfig<Language<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
    public override void Configure(EntityTypeBuilder<Language<TKey>> builder)
    {
        base.Configure(builder);
        builder.ToTable("language");
        builder
          .HasIndex(x => x.Code)
          .IsUnique();
    }
}