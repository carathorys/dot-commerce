// <copyright file="BaseDbContext.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{User,TRole,TKey,TUserClaim,TUserRole,TUserLogin,TRoleClaim,TUserToken}" />
public abstract class BaseDbContext<TKey> : IdentityDbContext<
  User<TKey>,
  Role<TKey>,
  TKey,
  UserClaim<TKey>,
  UserRole<TKey>,
  UserLogin<TKey>,
  RoleClaim<TKey>,
  UserToken<TKey>
>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{User,TRole,TKey,TUserClaim,TUserRole,TUserLogin,TRoleClaim,TUserToken}" />
  protected BaseDbContext(DbContextOptions options)
    : base(options)
  {
  }

  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.Entity<Role<TKey>>().SetupEntity<Role<TKey>, TKey>("identity_role");
    builder.Entity<RoleClaim<TKey>>().SetupEntity<RoleClaim<TKey>, TKey>("identity_role_claim");
    builder.Entity<User<TKey>>().SetupEntity<User<TKey>, TKey>("identity_user");
    builder.Entity<UserClaim<TKey>>().SetupEntity<UserClaim<TKey>, TKey>("identity_user_claim");
    builder.Entity<UserLogin<TKey>>().SetupEntity<UserLogin<TKey>, TKey>("identity_user_login");
    builder.Entity<UserRole<TKey>>().SetupEntity<UserRole<TKey>, TKey>("identity_user_role");
    builder.Entity<UserToken<TKey>>().SetupEntity<UserToken<TKey>, TKey>("identity_user_token");
  }
}

/// <inheritdoc cref="BaseDbContext{TKey}" />
public abstract class BaseDbContext : BaseDbContext<int>
{
  /// <inheritdoc cref="BaseDbContext{TKey}" />
  protected BaseDbContext(DbContextOptions options)
    : base(options)
  {
  }
}