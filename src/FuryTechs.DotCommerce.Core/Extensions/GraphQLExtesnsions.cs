using FuryTechs.DotCommerce.Core.GraphQL.Identity;
using FuryTechs.DotCommerce.Core.GraphQL.Identity.Types;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Identity;

namespace FuryTechs.DotCommerce.Core.Extensions;

/// <summary>
/// Helper class to extend the <see cref="IRequestExecutorBuilder"/>.
/// </summary>
public static class Extensions
{
  /// <summary>
  /// Adds the Mutations and Queries to the main GraphQL as Type Extensions.
  /// </summary>
  /// <param name="builder">GraphQL builder.</param>
  /// <typeparam name="TKey">Primary key type on identity tables.</typeparam>
  /// <returns>The modified builder.</returns>
  public static IRequestExecutorBuilder AddIdentity<TKey>(this IRequestExecutorBuilder builder)
    where TKey : IEquatable<TKey>
  {
    return builder
      .AddAuthorization()
      .AddTypeExtension<IdentityMutations<TKey>>()
      .AddTypeExtension<IdentityQueries<TKey>>()
      .AddType<LoginFailed>()
      .AddType<CurrentUser<TKey>>();
  }

  /// <summary>
  /// Creates a LoginFailed object from a <see cref="SignInResult"/>.
  /// </summary>
  /// <param name="result">Result what we're representing.</param>
  /// <returns>New instance of LoginFailed.</returns>
  public static LoginFailed ToFailedLoginResult(this SignInResult result)
  {
    return new LoginFailed
    {
      IsLockedOut = result.IsLockedOut,
      RequiresTwoFactor = result.RequiresTwoFactor,
    };
  }
}