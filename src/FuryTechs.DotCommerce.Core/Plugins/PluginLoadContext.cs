// <copyright file="PluginLoadContext.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Plugins;

using System.Reflection;
using System.Runtime.Loader;
using Path = System.IO.Path;

/// <inheritdoc />
internal class PluginLoadContext : AssemblyLoadContext
{
  private readonly AssemblyDependencyResolver resolver;

  /// <summary>
  /// Initializes a new instance of the <see cref="PluginLoadContext"/> class.
  /// </summary>
  /// <param name="pluginPath">Path of the plugin.</param>
  public PluginLoadContext(string pluginPath)
  {
    this.resolver = new AssemblyDependencyResolver(pluginPath);
  }

  /// <inheritdoc />
  protected override Assembly? Load(AssemblyName assemblyName)
  {
    var assemblyPath = this.resolver.ResolveAssemblyToPath(assemblyName);
    if (assemblyPath != null)
    {
      return this.LoadFromAssemblyPath(assemblyPath);
    }

    return null;
  }

  /// <inheritdoc/>
  protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
  {
    var libraryPath = this.resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
    if (libraryPath != null)
    {
      return this.LoadUnmanagedDllFromPath(libraryPath);
    }

    return IntPtr.Zero;
  }

  private static Assembly LoadPlugin(string relativePath, Type type)
  {
    // Navigate up to the solution root
    var root = Path.GetFullPath(Path.Combine(
      Path.GetDirectoryName(
        Path.GetDirectoryName(
          Path.GetDirectoryName(
            Path.GetDirectoryName(
              Path.GetDirectoryName(typeof(PluginLoadContext).Assembly.Location))))) ??
      throw new InvalidOperationException()));

    var pluginLocation = Path.GetFullPath(
      Path.Combine(
        root,
        relativePath.Replace('\\', Path.DirectorySeparatorChar)));

    Console.WriteLine($"Loading commands from: {pluginLocation}");
    var loadContext = new PluginLoadContext(pluginLocation);
    return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
  }
}