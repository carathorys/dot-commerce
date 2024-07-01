using FuryTechs.DotCommerce.Core.Database.Entities.System;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.TypeConfigurations.System;

public class ChannelTypeConfig<TKey> : DotCommerceEntityTypeConfig<Channel<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
    public override void Configure(EntityTypeBuilder<Channel<TKey>> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("channel");
        builder.Property(x => x.Token).IsRequired(true);
        builder.HasIndex(x => x.Token).IsUnique();

        builder.HasOne(x => x.DefaultLanguage).WithMany();
        builder.HasMany(x => x.AvailableLanguages).WithMany()
            .UsingEntity("channels_languages");
    }
}