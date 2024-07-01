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
  /// Name of the language (not translatable)
  /// </summary>
  [MaxLength(100)]
  public string DisplayName { get; set; }
  
  /// <summary>
  /// Code of the language
  /// </summary>
  [MaxLength(6)] 
  public string Code { get; set; }
}