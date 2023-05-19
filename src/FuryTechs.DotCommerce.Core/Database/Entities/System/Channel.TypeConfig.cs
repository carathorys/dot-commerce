using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.Entities.System;

public class ChannelTypeConfig<TKey> : IEntityTypeConfiguration<Channel<TKey>>
  where TKey : IEquatable<TKey>
{
  public void Configure(EntityTypeBuilder<Channel<TKey>> builder)
  {
    builder
      .Property(x => x.Token)
      .IsRequired(true);
    builder.ToTable("channel")
      .HasIndex(x => x.Token).IsUnique();
  }
}