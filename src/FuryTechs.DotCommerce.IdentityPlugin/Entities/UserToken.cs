// <copyright file="UserToken.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

using FuryTechs.DotCommerce.Core.Database.Base;

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using Microsoft.AspNetCore.Identity;

/// <inheritdoc cref="IdentityUserToken{TKey}"/>
public class UserToken<TKey> : IdentityUserToken<TKey>, ILogTimestamps, ILogicalDelete
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public DateTimeOffset CreatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset UpdatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset? DeletedAt { get; set; }
}