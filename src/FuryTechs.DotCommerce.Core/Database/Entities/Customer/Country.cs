using System.ComponentModel.DataAnnotations.Schema;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using FuryTechs.DotCommerce.Core.Database.Entities.System;

namespace FuryTechs.DotCommerce.Core.Database.Entities.Customer;

[Table("country_translation")]
public class CountryTranslation<TKey> : EntityTranslation<TKey, Country<TKey>>
    where TKey : IEquatable<TKey>
{
    public override required Language<TKey> Language { get; set; }
    public required string CountryName { get; set; }
}

[Table("country")]
public class Country<TKey> : MultilLingualObject<TKey, CountryTranslation<TKey>, Country<TKey>>
  where TKey : IEquatable<TKey>
{
    public required string CountryCode { get; set; }
}