// <copyright file="UserRole.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.AspNetCore.Identity;

/// <inheritdoc cref="IdentityUserRole{TKey}" />
public class UserRole<TKey> : IdentityUserRole<TKey>, ILogTimestamps, ILogicalDelete
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public DateTimeOffset CreatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset UpdatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset? DeletedAt { get; set; }
}