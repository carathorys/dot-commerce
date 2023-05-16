// <copyright file="Address.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.CustomerPlugin.Database;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class AddressEntityTypeConfiguration<TKey> : DotCommerceEntityTypeConfig<Address<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public override void Configure(EntityTypeBuilder<Address<TKey>> builder)
  {
    base.Configure(builder);
  }
}