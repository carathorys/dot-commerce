using FuryTechs.DotCommerce.Core.Database.Entities.Base;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Customer;

public class Address<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// The full name, who's this address (not necessarily the customer's name)
  /// </summary>
  public string FullName { get; set; } = default!;
  /// <summary>
  /// (Optional) Company name for address
  /// </summary>
  public string? CompanyName { get; set; }

  /// <summary>
  /// First line of the street details
  /// </summary>
  public string StreetLine1 { get; set; } = default!;
  
  /// <summary>
  /// Second line of the street details
  /// </summary>
  public string? StreetLine2 { get; set; }

  /// <summary>
  /// City name
  /// </summary>
  public string City { get; set; } = default!;

  /// <summary>
  /// Province name
  /// </summary>
  public string? Province { get; set; }

  /// <summary>
  /// Phone number for the address
  /// </summary>
  public string PhoneNumber { get; set; } = default!;
  public bool DefaultShippingAddress { get; set; }
  public bool DefaultBillingAddress { get; set; }

  public Customer<TKey> Customer { get; set; }
}