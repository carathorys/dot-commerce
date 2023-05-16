// <copyright file="CustomerPlugin.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.CustomerPlugin;

using FuryTechs.DotCommerce.Core.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Customer plugin.
/// </summary>
public class CustomerPlugin : IDotCommercePlugin
{
  /// <inheritdoc/>
  public string Name => "Customer plugin";

  /// <inheritdoc/>
  public string? Description => "Customer related stuff is defined in this plugin.";

  /// <inheritdoc/>
  public void InitializePlugin(IServiceCollection services, IConfiguration configuration)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc/>
  public void SetupApplication(IApplicationBuilder app)
  {
    throw new NotImplementedException();
  }
}