using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.System;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Customer;

public class Country<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  public TranslatableString<TKey> CountryName { get; set; }
  public TranslatableString<TKey> OtherTranslatableProperty { get; set; }
}