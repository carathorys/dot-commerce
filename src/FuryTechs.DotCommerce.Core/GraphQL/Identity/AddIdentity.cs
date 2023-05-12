using FuryTechs.DotCommerce.Core.GraphQL.Identity.Models;
using FuryTechs.DotCommerce.Core.GraphQL.Identity.Models.Login;

namespace FuryTechs.DotCommerce.Core.GraphQL.Identity
{
  using HotChocolate.Execution.Configuration;

  /// <summary>
  /// Helper class to extend the <see cref="IRequestExecutorBuilder"/>.
  /// </summary>
  public static class AddIdentity
  {
    /// <summary>
    /// Adds the Mutations and Queries to the main GraphQL as Type Extensions.
    /// </summary>
    /// <param name="builder">GraphQL builder.</param>
    /// <returns>The modified builder.</returns>
    public static IRequestExecutorBuilder AddIdentityExtension(this IRequestExecutorBuilder builder)
    {
      return builder
        .AddTypeExtension<IdentityMutations>()
        .AddTypeExtension<IdentityQueries>()
        .AddType<LoginFailed>()
        .AddType<CurrentUser>();
    }
  }
}