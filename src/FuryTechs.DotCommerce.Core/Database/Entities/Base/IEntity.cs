namespace FuryTechs.DotCommerce.Core.Database.Entities.Base;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// IEntity interface to define an entity in this system.
/// </summary>
/// <typeparam name="TKey">Type of the primary key.</typeparam>
public interface IEntity<TKey>
  where TKey : IEquatable<TKey>
{
  /// <summary>
  /// Primary key of an entity.
  /// </summary>
  [Key]
  public TKey Id { get; set; }
}