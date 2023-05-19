using System.Reflection;
using FuryTechs.DotCommerce.Core.Database.Entities.Customer;
using FuryTechs.DotCommerce.Core.Database.Entities.System;

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
    builder.Entity<Channel<TKey>>();

    var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
      .Where(t => t.GetInterfaces().Any(gi =>
        gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();


    foreach (var configurationInstance in typesToRegister
               .Select(type => type.IsGenericType switch
               {
                 // For generic type, if the TypeParameter is TKey only,
                 // provide the type of TKey generic parameter
                 true when type
                   .GetGenericArguments()
                   .All(x => x.Name == nameof(TKey)) => type.MakeGenericType(typeof(TKey)),
                 // If not a generic type, simply create a new instance from it
                 false => type,
                 // Otherwise throw new InvalidOperationException
                 _ => throw new InvalidOperationException()
               })
               .Select(finalType =>
                 Activator.CreateInstance(finalType) ?? throw new InvalidOperationException()
               )
            )
    {
      builder.ApplyConfiguration((dynamic)configurationInstance);
    }
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