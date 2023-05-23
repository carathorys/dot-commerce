using System.Reflection;
using FuryTechs.DotCommerce.Core.Database.Entities.Customer;
using FuryTechs.DotCommerce.Core.Database.Entities.System;
using FuryTechs.DotCommerce.Core.Database.TypeConfigurations.Base;

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

    var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
      .Where(t => !t.IsAbstract && t.GetInterfaces().Any(gi =>
        gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IDotCommerceEntityTypeConfig<>))).ToList();


    foreach (var configurationInstance in typesToRegister
               .Select(type => type.IsGenericType switch
               {
                 // For generic type, if the TypeParameter is TKey only,
                 // provide the type of TKey generic parameter
                 true when type
                   .GetGenericArguments()
                   .All(x => x is { Name: nameof(TKey), IsAbstract: false }) => type.MakeGenericType(typeof(TKey)),
                 // If not a generic type, simply create a new instance from it
                 false => type,
                 // Otherwise return with a default value (null)
                 _ => default
               })
               .Select(finalType => finalType != default ? Activator.CreateInstance(finalType) : default)
            )
    {
      if (configurationInstance != default)
      {
        builder.ApplyConfiguration((dynamic)configurationInstance);
      }
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