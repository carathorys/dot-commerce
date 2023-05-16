// <copyright file="BaseDbContext.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="IdentityDbContext" />
public abstract partial class BaseDbContext : DbContext
{
  /// <inheritdoc cref="IdentityDbContext" />
  protected BaseDbContext(DbContextOptions options)
    : base(options)
  {
  }

}