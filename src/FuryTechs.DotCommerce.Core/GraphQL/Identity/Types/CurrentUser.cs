// <copyright file="CurrentUser.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Types;

/// <summary>
/// Currently signed in user.
/// </summary>
/// <typeparam name="TKey">Type of the primary key.</typeparam>
[GraphQLName("CurrentUser")]
public class CurrentUser<TKey> : ILoginResult
  where TKey : IEquatable<TKey>
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

public class CurrentUserType<TKey>: ObjectType<CurrentUser<TKey>>
  where TKey : IEquatable<TKey>
{
    protected override void Configure(IObjectTypeDescriptor<CurrentUser<TKey>> descriptor)
    {
        base.Configure(descriptor);
        descriptor.Name("CurrentUser");
    }
}