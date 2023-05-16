// <copyright file="Customer.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.CustomerPlugin.Database;

using FuryTechs.DotCommerce.Core.Database.Base;
using FuryTechs.DotCommerce.IdentityPlugin.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The Customer entity.
/// </summary>
/// <typeparam name="TKey">Type of the primary key.</typeparam>
[EntityTypeConfiguration(typeof(CustomerEntityTypeConfiguration<>))]
public class Customer<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// Title of the customer.
  /// </summary>
  public string? Title { get; set; }

  /// <summary>
  /// First name of the customer.
  /// </summary>
  public string FirstName { get; set; } = default!;

  /// <summary>
  /// Last name of the customer.
  /// </summary>
  public string LastName { get; set; } = default!;

  /// <summary>
  /// Phone number of the customer.
  /// </summary>
  public string PhoneNumber { get; set; } = default!;

  /// <summary>
  /// The E-mail address of the customer.
  /// </summary>
  public string EmailAddress { get; set; } = default!;

  /// <summary>
  /// If the customer is not a guest, a user should belong to him/her.
  /// </summary>
  public User<TKey>? User { get; set; }
}