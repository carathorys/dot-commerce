// <copyright file="LoginFailed.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Types;

/// <summary>
/// Represents a failed login attempt. Some details can be given, but nothing more should go out.
/// </summary>
public record LoginFailed : ILoginResult
{
  /// <summary>
  /// Initializes a new instance of the <see cref="LoginFailed"/> class.
  /// </summary>
  internal LoginFailed()
  {
  }

  /// <summary>
  /// Indicates whether the user attempting to sign-in is locked out.
  /// </summary>
  public bool IsLockedOut { get; init; }

  /// <summary>
  /// Indicates whether the user attempting to sign-in requires two factor authentication.
  /// </summary>
  public bool RequiresTwoFactor { get; init; }
}