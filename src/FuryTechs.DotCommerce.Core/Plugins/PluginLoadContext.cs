// <copyright file="AssemblyLoadContext.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;
using Path = System.IO.Path;

namespace FuryTechs.DotCommerce.Core.Plugins;

using System.Reflection;
using System.Runtime.Loader;

class PluginLoadContext : AssemblyLoadContext
{
  private readonly AssemblyDependencyResolver _resolver;

  /// <summary>
  /// Initializes a new instance of the <see cref="PluginLoadContext"/> class.
  /// </summary>
  /// <param name="pluginPath">Path of the plugin.</param>
  public PluginLoadContext(string pluginPath)
  {
    this._resolver = new AssemblyDependencyResolver(pluginPath);
  }

  static Assembly LoadPlugin(string relativePath, Type type)
  {
    // Navigate up to the solution root
    var root = Path.GetFullPath(Path.Combine(
      Path.GetDirectoryName(
        Path.GetDirectoryName(
          Path.GetDirectoryName(
            Path.GetDirectoryName(
              Path.GetDirectoryName(typeof(PluginLoadContext).Assembly.Location))))) ?? throw new InvalidOperationException()));

    var pluginLocation = Path.GetFullPath(
      Path.Combine(
        root,
        relativePath.Replace('\\', Path.DirectorySeparatorChar)));

    Console.WriteLine($"Loading commands from: {pluginLocation}");
    var loadContext = new PluginLoadContext(pluginLocation);
    return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
  }

  /// <inheritdoc/>
  protected override Assembly? Load(AssemblyName assemblyName)
  {
    var assemblyPath = this._resolver.ResolveAssemblyToPath(assemblyName);
    if (assemblyPath != null)
    {
      return this.LoadFromAssemblyPath(assemblyPath);
    }

    return null;
  }

  /// <inheritdoc/>
  protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
  {
    var libraryPath = this._resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
    if (libraryPath != null)
    {
      return this.LoadUnmanagedDllFromPath(libraryPath);
    }

    return IntPtr.Zero;
  }
}