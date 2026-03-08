// <copyright file="DotCommerceMockPlugin.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Plugins;

/// <summary>
/// A mock implementation of the plugin interface for testing purposes.
/// </summary>
public class DotCommerceMockPlugin : IDotCommercePlugin
{
    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc cref="IDotCommercePlugin.Description"/>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DotCommerceMockPlugin"/> class.
    /// </summary>
    /// <param name="name">Name of the plugin.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty.</exception>
    public DotCommerceMockPlugin(string name) : this(name, string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DotCommerceMockPlugin"/> class.
    /// </summary>
    /// <param name="name">Name of the plugin.</param>
    public DotCommerceMockPlugin(string name, string? description)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentException.ThrowIfNullOrEmpty(name);

        this.Name = name;
        this.Description = description;
    }

    /// <inheritdoc/>
    void IDotCommercePlugin.InitializePlugin(IServiceCollection services, IConfiguration configuration)
    {
        // Default implementation - no-op
    }

    /// <inheritdoc/>
    void IDotCommercePlugin.SetupApplication(IApplicationBuilder app)
    {
        // Default implementation - no-op
    }
}
