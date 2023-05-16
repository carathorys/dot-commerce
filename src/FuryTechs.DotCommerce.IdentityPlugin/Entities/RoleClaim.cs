// <copyright file="RoleClaim.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IdentityRoleClaim{TKey}" />
[EntityTypeConfiguration(typeof(RoleClaimTypeConfig<>))]
public class RoleClaim<TKey> : IdentityRoleClaim<TKey>, IEntity<int>, ILogTimestamps
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public DateTimeOffset CreatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset UpdatedAt { get; set; }
}