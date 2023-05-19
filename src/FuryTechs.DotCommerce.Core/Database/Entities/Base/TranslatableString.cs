using FuryTechs.DotCommerce.Core.Database.Entities.System;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Base;

public class TranslatableString<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  public virtual List<Translation<TKey>> Translations { get; set; } = new();
}