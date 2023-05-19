using FuryTechs.DotCommerce.Core.Database.Entities.Base;

namespace FuryTechs.DotCommerce.Core.Database.Entities.System;

public class Translation<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  public Language<TKey> Language { get; set; }
}