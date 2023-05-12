namespace FuryTechs.DotCommerce.Core.Database.Base
{
  public interface ILogTimestamps<T> : IEntity<T>
  {
    /// <summary>
    /// The timestamp when the entity was created
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    /// <summary>
    /// The timestamp when the entity was updated last time
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
  }
}