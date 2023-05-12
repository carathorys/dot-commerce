using FuryTechs.DotCommerce.Core.GraphQL.Identity.Models.Login;

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity
{
  using FuryTechs.DotCommerce.Core.Database.Identity;
  using FuryTechs.DotCommerce.Core.GraphQL.Identity.Models;
  using HotChocolate.Authorization;
  using Microsoft.AspNetCore.Identity;

  /// <summary>
  /// Mutations around Identity (login, logout, basic registration).
  /// These methods will extend the existing <see cref="Mutations"/> class.
  /// </summary>
  [ExtendObjectType<Mutations>]
  public sealed class IdentityMutations
  {
    /// <summary>
    /// A mutation for the users to Log in to the application.
    /// </summary>
    /// <param name="username">User's name.</param>
    /// <param name="password">User's password.</param>
    /// <param name="rememberMe">Remember me flag.</param>
    /// <param name="signInManager">Dependency: signInManager instance.</param>
    /// <returns>Result of the signIn: <see cref="SignInResult"/></returns>
    public async Task<ILoginResult> Login(
      string username,
      string password,
      bool? rememberMe,
      [Service] SignInManager<User> signInManager)
    {
      var result = await signInManager.PasswordSignInAsync(username, password, rememberMe == true, true);
      if (!result.Succeeded)
      {
        return LoginFailed.FromSignInResult(result);
      }

      return new CurrentUser
      {
        Id = Guid.Empty,
        Identifier = username,
      };
    }


    /// <summary>
    /// Mutation method to log out logged in user.
    /// </summary>
    /// <param name="signInManager">Dependency: signInManager instance.</param>
    /// <param name="accessor">Dependency: HTTP Context Accessor instance.</param>
    /// <returns><value>true</value> after a successful logout, <value>false</value> otherwise.</returns>
    [Authorize]
    public async Task<bool> Logout([Service] SignInManager<User> signInManager, [Service] IHttpContextAccessor
      accessor)
    {
      if (accessor.HttpContext?.User == null || !signInManager.IsSignedIn(accessor.HttpContext.User))
      {
        return false;
      }

      await signInManager.SignOutAsync();
      return true;
    }

    // TODO: Add docs
    public async Task<bool> LoginWithTotp(string username, string password, string totp, bool rememberMe = false)
    {
      await Task.CompletedTask;
      return username == "admin" && password == "password";
    }

    // TODO: Add docs
    public async Task<IdentityResult> Register(
      RegistrationModel input,
      string password,
      [Service] UserManager<User> userManager)
    {
      return await userManager.CreateAsync(
        new User()
        {
          FirstName = input.FirstName,
          LastName = input.LastName,
          Email = input.EmailAddress,
          UserName = input.EmailAddress,
        },
        password);
    }
  }
}