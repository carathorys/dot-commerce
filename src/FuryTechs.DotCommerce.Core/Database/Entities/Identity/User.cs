namespace FuryTechs.DotCommerce.Core.Database.Entities.Identity;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Microsoft.AspNetCore.Identity;

/// <inheritdoc cref="IdentityUser{TKey}"/>
public class User<TKey> : IdentityUser<TKey>, IEntity<TKey>, ILogTimestamps
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc/>
  public DateTimeOffset CreatedAt { get; set; }

  /// <inheritdoc/>
  public DateTimeOffset UpdatedAt { get; set; }
}