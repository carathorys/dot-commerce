// <copyright file="IDotCommercePlugin.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Plugins;

/// <summary>
/// Interface for define a plugin for this application.
/// </summary>
public interface IDotCommercePlugin
{
  /// <summary>
  /// Required: Name of the plugin.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// Optional: description of the plugin.
  /// </summary>
  public string? Description { get; }

  /// <summary>
  /// Provide an initialization mechanism for the application.
  /// This will be invoked once we load a plugin into the memory.
  /// </summary>
  /// <param name="services">ServiceCollection use to register dependencies.</param>
  /// <param name="configuration">Configuration elements regarding to the plugin.</param>
  void InitializePlugin(IServiceCollection services, IConfiguration configuration);

  /// <summary>
  /// A mechanism to set plugin related application settings.
  /// </summary>
  /// <param name="app">IApplicationBuilder instance.</param>
  void SetupApplication(IApplicationBuilder app);
}