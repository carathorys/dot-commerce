using System.ComponentModel.DataAnnotations;
using FuryTechs.DotCommerce.Core.Database.Entities.Base;

namespace FuryTechs.DotCommerce.Core.Database.Entities.System;

public class Options<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  [MaxLength(200)]
  public string Key { get; set; } = default!;
  [MaxLength(int.MaxValue)]
  public string Value { get; set; } = default!;
}