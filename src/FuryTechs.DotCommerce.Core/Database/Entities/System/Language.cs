using System.ComponentModel.DataAnnotations;
using FuryTechs.DotCommerce.Core.Database.Entities.Base;

namespace FuryTechs.DotCommerce.Core.Database.Entities.System;

/// <summary>
/// Represents a language
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class Language<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// 
  /// </summary>
  [MaxLength(5)][Required(AllowEmptyStrings = false)] public string CountryCode { get; set; } = default!;

  public bool IsDefault { get; set; }
}