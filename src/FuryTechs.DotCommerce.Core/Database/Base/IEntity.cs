using System.ComponentModel.DataAnnotations;

namespace FuryTechs.DotCommerce.Core.Database.Base
{
  public interface IEntity<T>
  {
    [Key] public T Id { get; set; }
  }
}