namespace FuryTechs.DotCommerce.Core.GraphQL.Identity.Models;

/// <summary>
/// Model for register a new account.
/// </summary>
public record RegistrationModel
{
  /// <summary>
  /// Gets or sets the first name of the registering user.
  /// </summary>
  public string FirstName { get; set; } = default!;

  /// <summary>
  /// Gets or sets the last name of the registering user.
  /// </summary>
  public string LastName { get; set; } = default!;

  /// <summary>
  /// Gets or sets the email address of the registering user.
  /// </summary>
  public string EmailAddress { get; set; } = default!;
}