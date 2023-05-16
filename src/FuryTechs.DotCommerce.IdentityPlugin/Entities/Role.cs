// <copyright file="Role.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IdentityRole{TKey}"/>
[EntityTypeConfiguration(typeof(RoleTypeConfig<>))]
public class Role<TKey> : IdentityRole<TKey>, IEntity<TKey>, ILogTimestamps
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public DateTimeOffset CreatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset UpdatedAt { get; set; }
}