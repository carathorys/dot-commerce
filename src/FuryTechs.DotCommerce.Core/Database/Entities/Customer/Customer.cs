using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Customer;

public class Customer<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// The title of the customer 
  /// </summary>
  public string? Title { get; set; }

  /// <summary>
  /// First name of the customer
  /// </summary>
  public string FirstName { get; set; } = default!;

  /// <summary>
  /// The last name of the customer
  /// </summary>
  public string LastName { get; set; } = default!;

  public string EmailAddress { get; set; } = default!;

  public string? PhoneNumber { get; set; }

  public List<CustomerGroup<TKey>> Groups { get; } = new();
  public List<Address<TKey>> Addresses { get; } = new();

  public User<TKey>? User { get; set; }
}