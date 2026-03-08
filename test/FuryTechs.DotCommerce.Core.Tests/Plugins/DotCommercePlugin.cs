// <copyright file="DotCommercePlugin.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Plugins;

/// <summary>
/// Default implementation of the plugin interface with null name validation and empty string throwing exception.
/// </summary>
public class DotCommercePlugin : IDotCommercePlugin
{
    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc cref="IDotCommercePlugin.Description"/>
    public string? Description { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DotCommercePlugin"/> class.
    /// </summary>
    /// <param name="name">Name of the plugin.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty.</exception>
    public DotCommercePlugin(string name) : this(name, string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DotCommercePlugin"/> class.
    /// </summary>
    /// <param name="name">Name of the plugin.</param>
    /// <param name="description">Optional description of the plugin.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is empty.</exception>
    public DotCommercePlugin(string name, string? description)
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
