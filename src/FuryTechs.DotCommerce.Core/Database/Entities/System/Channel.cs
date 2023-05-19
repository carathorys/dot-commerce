using System.ComponentModel.DataAnnotations;
using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuryTechs.DotCommerce.Core.Database.Entities.System;

public class Channel<TKey> : DotCommerceEntity<TKey>
  where TKey : IEquatable<TKey>
{
  [MaxLength(32)] public string Token { get; set; }

  [MaxLength(512)] public string Description { get; set; }
  // public Language<TKey> DefaultLanguage { get; set; }
}
