// <copyright file="Address.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.CustomerPlugin.Database;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc />
[EntityTypeConfiguration(typeof(AddressEntityTypeConfiguration<>))]
public class Address<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// The customer, who created this address in the system.
  /// </summary>
  public Customer<TKey> Customer { get; set; } = default!;

  /// <summary>
  /// Recipient name.
  /// </summary>
  public string? Recipient { get; set; }

  /// <summary>
  /// City of destination.
  /// </summary>
  public string? City { get; set; }

  /// <summary>
  /// Street lines.
  /// </summary>
  public string? StreetLines { get; set; }
}