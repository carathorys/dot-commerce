namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Models;

using FuryTechs.DotCommerce.Core.GraphQL.Identity.Models.Login;

/// <summary>
/// Currently signed in user.
/// </summary>
public class CurrentUser : ILoginResult
{
  /// <summary>
  /// Gets the ID of the user.
  /// </summary>
  [ID]
  public Guid Id { get; init; } = Guid.Empty;

  /// <summary>
  /// Gets the Identifier of the user (`UserName` field's value address by default).
  /// </summary>
  public string Identifier { get; init; } = default!;
}