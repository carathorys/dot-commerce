using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using FuryTechs.DotCommerce.Core.Database.Identity;
using Microsoft.AspNetCore.Identity;

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity
{
  using FuryTechs.DotCommerce.Core.GraphQL.Identity.Models;
  using HotChocolate.Authorization;

  /// <summary>
  /// Queries for Identity.
  /// These methods will extend the existing <see cref="Queries" /> class.
  /// </summary>
  [ExtendObjectType<Queries>]
  public class IdentityQueries
  {
    /// <summary>
    /// Query the active user.
    /// </summary>
    /// <param name="httpContextAccessor">Dependency: Accessor for HTTP context.</param>
    /// <param name="signInManager">Dependency: SignInManager instance</param>
    /// <returns>Result some details about the active user.</returns>
    [Authorize]
    public async Task<CurrentUser> Me(
      [Service] IHttpContextAccessor httpContextAccessor,
      [Service] SignInManager<User> signInManager)
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

      return new CurrentUser() { Identifier = user.UserName!, Id = user.Id };
    }
  }
}