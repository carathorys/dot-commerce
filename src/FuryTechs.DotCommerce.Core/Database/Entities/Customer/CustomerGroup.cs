using FuryTechs.DotCommerce.Core.Database.Entities.Base;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Customer;

/// <summary>
/// Represents a customer group.
/// </summary>
/// <typeparam name="TKey">The type of the primary key</typeparam>
public class CustomerGroup<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// Name of the group.
  /// </summary>
  public string Name { get; set; } = default!;

  /// <summary>
  /// Customers in the group.
  /// </summary>
  public List<Customer<TKey>> Customers { get; } = new();
}