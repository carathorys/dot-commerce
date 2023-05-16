// <copyright file="UserLogin.TypeConfig.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.IdentityPlugin.Entities;

using FuryTechs.DotCommerce.Core.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <inheritdoc />
public class UserLoginTypeConfig<TKey> : LogTimestampsTypeConfig<UserLogin<TKey>>
  where TKey : IEquatable<TKey>
{
  /// <inheritdoc cref="LogTimestampsTypeConfig{TEntity}" />
  public override void Configure(EntityTypeBuilder<UserLogin<TKey>> entity)
  {
    base.Configure(entity);
    entity.ToTable("identity_user_login");
  }
}