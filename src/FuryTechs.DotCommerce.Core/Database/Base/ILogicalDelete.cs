using FuryTechs.BLM.NetStandard.Attributes;

namespace FuryTechs.DotCommerce.Core.Database.Base
{
  public interface ILogicalDelete<T>: IEntity<T>
  {
    /// <summary>
    /// Indicates if an entity was deleted
    /// </summary>
    [LogicalDelete]
    public DateTimeOffset? DeletedAt { get; set; }
  }
}