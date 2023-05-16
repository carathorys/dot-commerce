// ReSharper disable once CheckNamespace

namespace FuryTechs.DotCommerce.Core.Database;

using FuryTechs.DotCommerce.IdentityPlugin.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

/// <inheritdoc />
public abstract partial class BaseDbContext<TKey> : IdentityDbContext<
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
}