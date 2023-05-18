// <copyright file="UserRole.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Entities.Identity;

using System.ComponentModel.DataAnnotations.Schema;
using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Microsoft.AspNetCore.Identity;

/// <inheritdoc cref="IdentityUserRole{TKey}" />
[Table("identity_user_role")]
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