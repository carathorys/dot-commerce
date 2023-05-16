// <copyright file="IdentityPlugin.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

using FuryTechs.DotCommerce.IdentityPlugin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FuryTechs.DotCommerce.IdentityPlugin;

using FuryTechs.DotCommerce.Core.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

/// <inheritdoc />
public class IdentityPlugin<TKey, TDbContext> : IDotCommercePlugin
  where TKey : IEquatable<TKey>
  where TDbContext : DbContext
{
  /// <inheritdoc/>
  public string Name => "FuryTechs.DotCommerce.IdentityPlugin";

  /// <inheritdoc/>
  public string? Description => null;

  /// <inheritdoc/>
  public void InitializePlugin(IServiceCollection services, IConfiguration configuration)
  {
    services
      .AddIdentity<User<TKey>, Role<TKey>>(
        options => configuration.Bind("IdentityOptions", options))
      .AddEntityFrameworkStores<TDbContext>();

    services.UpgradePasswordSecurity()
      .WithMemLimit(33554432)
      .WithOpsLimit(4L)
      .UseArgon2<User<TKey>>();
  }


  /// <inheritdoc/>
  public void SetupApplication(IApplicationBuilder app)
  {
    app
      .UseAuthentication()
      .UseAuthorization();
  }
}