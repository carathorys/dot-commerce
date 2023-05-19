namespace FuryTechs.DotCommerce.Core.Database.Entities.Identity;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
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