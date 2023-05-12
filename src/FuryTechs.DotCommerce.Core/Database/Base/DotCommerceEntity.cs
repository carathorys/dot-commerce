using System.ComponentModel.DataAnnotations;
using FuryTechs.BLM.NetStandard.Attributes;
using Microsoft.EntityFrameworkCore;

namespace FuryTechs.DotCommerce.Core.Database.Base
{
  [Index(nameof(DeletedAt))]
  [Index(nameof(CreatedAt))]
  [Index(nameof(UpdatedAt))]
  public abstract class DotCommerceEntity : ILogicalDelete<Guid>, ILogTimestamps<Guid>
  {
    /// <inheritdoc cref="IEntity{T}.Id"/>
    [Key]
    public Guid Id { get; set; }

    /// <inheritdoc cref="ILogicalDelete{T}.DeletedAt"/>
    [LogicalDelete]
    public DateTimeOffset? DeletedAt { get; set; }

    /// <inheritdoc cref="ILogTimestamps{T}.CreatedAt"/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc cref="ILogTimestamps{T}.UpdatedAt"/>
    public DateTimeOffset UpdatedAt { get; set; }
  }
}