using System.ComponentModel.DataAnnotations;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;

namespace FuryTechs.DotCommerce.Core.Database.Entities.System;

public class Channel<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
    [MaxLength(64)] public required string Token { get; set; }

    [MaxLength(512)] public required string Description { get; set; }
    public required Language<TKey> DefaultLanguage { get; set; }
    public required ICollection<Language<TKey>> AvailableLanguages { get; set; }
}
