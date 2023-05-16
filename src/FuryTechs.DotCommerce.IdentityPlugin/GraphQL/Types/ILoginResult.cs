// <copyright file="ILoginResult.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.GraphQL.Types;

using HotChocolate.Types;

/// <summary>
/// Result of a login attempt.
/// </summary>
[UnionType("LoginResult")]
public interface ILoginResult
{
}