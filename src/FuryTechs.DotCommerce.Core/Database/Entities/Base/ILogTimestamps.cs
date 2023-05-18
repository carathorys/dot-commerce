namespace FuryTechs.DotCommerce.Core.Database.Entities.Base;

/// <summary>
/// A common interface to handle entity creation, and update timestamps.
/// </summary>
public interface ILogTimestamps
{
  /// <summary>
  /// Gets or sets the timestamp when the entity was created. This timestamp will be populated automatically by the database, and can
  /// not be updated manually later.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Gets or sets the timestamp when the entity was updated last time. This timestamp will be populated, and updated automatically by
  /// the database, and can not be manually override.
  /// </summary>
  public DateTimeOffset UpdatedAt { get; set; }
}