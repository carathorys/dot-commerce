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
      .Property(x => x.Token)
      .IsRequired(true);
    builder.ToTable("channel")
      .HasIndex(x => x.Token).IsUnique();
  }
}