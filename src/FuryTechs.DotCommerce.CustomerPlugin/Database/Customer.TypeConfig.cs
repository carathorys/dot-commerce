// <copyright file="Customer.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.CustomerPlugin.Database;

using FuryTechs.DotCommerce.Core.Database.Base;
using FuryTechs.DotCommerce.IdentityPlugin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class CustomerEntityTypeConfiguration<TKey> : DotCommerceEntityTypeConfig<Customer<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public override void Configure(EntityTypeBuilder<Customer<TKey>> builder)
  {
    base.Configure(builder);
    builder.HasIndex(x => x.EmailAddress);
    builder
      .HasOne<User<TKey>>(x => x.User)
      .WithOne()
      .OnDelete(DeleteBehavior.Restrict)
      .IsRequired(false)
      .HasForeignKey<Customer<TKey>>("UserId");
  }
}