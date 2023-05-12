using Microsoft.AspNetCore.Identity;

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Models.Login;

/// <summary>
/// Represents a failed login attempt. Some details can be given, but nothing more should go out.
/// </summary>
public record LoginFailed : ILoginResult
{
  private LoginFailed()
  {
  }

  /// <summary>
  /// Creates a LoginFailed object from a <see cref="SignInResult"/>.
  /// </summary>
  /// <param name="result">Result what we're representing.</param>
  /// <returns>New instance of LoginFailed.</returns>
  public static LoginFailed FromSignInResult(SignInResult result)
  {
    return new LoginFailed
    {
      IsLockedOut = result.IsLockedOut,
      RequiresTwoFactor = result.RequiresTwoFactor,
    };
  }

  /// <summary>
  /// Returns a flag indication whether the user attempting to sign-in is locked out.
  /// </summary>
  /// <value>True if the user attempting to sign-in is locked out, otherwise false.</value>
  public bool IsLockedOut { get; init; } = false;

  /// <summary>
  /// Returns a flag indication whether the user attempting to sign-in requires two factor authentication.
  /// </summary>
  /// <value>True if the user attempting to sign-in requires two factor authentication, otherwise false.</value>
  public bool RequiresTwoFactor { get; init; } = false;
}