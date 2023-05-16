// <copyright file="User.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class UserTypeConfig<TKey> : DotCommerceEntityTypeConfig<User<TKey>, TKey>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc cref="DotCommerceEntityTypeConfig{T,TKey}" />
  public override void Configure(EntityTypeBuilder<User<TKey>> entity)
  {
    base.Configure(entity);
    entity.ToTable(name: "identity_user");
  }
}