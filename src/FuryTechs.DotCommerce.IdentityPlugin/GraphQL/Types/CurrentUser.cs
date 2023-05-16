// <copyright file="CurrentUser.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.GraphQL.Types;

using HotChocolate.Types.Relay;

/// <summary>
/// Currently signed in user.
/// </summary>
public class CurrentUser<TKey> : ILoginResult
{
  /// <summary>
  /// The ID of the user.
  /// </summary>
  [ID]
  public TKey Id { get; init; } = default!;

  /// <summary>
  /// The Identifier of the user (`UserName` field's value address by default).
  /// </summary>
  public string Identifier { get; init; } = default!;
}