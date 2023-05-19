namespace FuryTechs.DotCommerce.Core.Database.Entities.Identity;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Microsoft.AspNetCore.Identity;

/// <inheritdoc cref="IdentityRoleClaim{TKey}" />
public class RoleClaim<TKey> : IdentityRoleClaim<TKey>, IEntity<int>, ILogTimestamps
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public DateTimeOffset CreatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset UpdatedAt { get; set; }
}