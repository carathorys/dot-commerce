// <copyright file="ILogicalDelete.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Database.Entities.Base;

using FuryTechs.BLM.NetStandard.Attributes;

/// <summary>
/// Common interface to handle logical deleting entities.
/// </summary>
public interface ILogicalDelete
{
  /// <summary>
  /// <value>null</value> when an entity is not deleted logically, otherwise the timestamp when it got deleted.
  /// </summary>
  [LogicalDelete]
  public DateTimeOffset? DeletedAt { get; set; }
}