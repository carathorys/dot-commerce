// <copyright file="IdentityQueries.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.GraphQL.Identity.Types;

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity;

using System.Security.Claims;

using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Queries for Identity.
/// These methods will extend the existing <see cref="Queries" /> class.
/// </summary>
/// <typeparam name="TKey">Primary key type on identity tables.</typeparam>
[ExtendObjectType("Queries")]
public class IdentityQueries<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// Query the active user.
  /// </summary>
  /// <param name="httpContextAccessor">Dependency: Accessor for HTTP context.</param>
  /// <param name="signInManager">Dependency: SignInManager instance.</param>
  /// <returns>Result some details about the active user.</returns>
  [Authorize]
  public async Task<CurrentUser<TKey>> Me(
    [Service] IHttpContextAccessor httpContextAccessor,
    [Service] SignInManager<User<TKey>> signInManager)
  {
    var userName = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (userName == null)
    {
      throw new UnauthorizedAccessException();
    }

    var user = await signInManager.UserManager.FindByIdAsync(userName);
    if (user == null)
    {
      throw new UnauthorizedAccessException();
    }

    return new CurrentUser<TKey>() { Identifier = user.UserName!, Id = user.Id };
  }
}