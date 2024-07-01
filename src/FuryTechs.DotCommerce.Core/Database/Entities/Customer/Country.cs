using System.ComponentModel.DataAnnotations.Schema;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.System;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Customer;

[Table("country_translation")]
public class CountryTranslation<TKey> : EntityTranslation<TKey, Country<TKey>>
    where TKey : IEquatable<TKey>
{
    public Language<TKey> Language { get; set; }
    public string CountryName { get; set; }
}

[Table("country")]
public class Country<TKey> : MultilLingualObject<TKey, CountryTranslation<TKey>, Country<TKey>>
  where TKey : IEquatable<TKey>
{
    public ICollection<CountryTranslation<TKey>> Translations { get; set; }

    public string CountryCode { get; set; }
}