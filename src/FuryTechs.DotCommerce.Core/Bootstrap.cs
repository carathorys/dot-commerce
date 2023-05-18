// <copyright file="Bootstrap.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core
{
  using FuryTechs.DotCommerce.Core.Database;
  using FuryTechs.DotCommerce.Core.Extensions;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  /// <summary>
  /// Temporary class to help bootstrapping application.
  /// </summary>
  /// <typeparam name="TDbContext">Type of the database context.</typeparam>
  /// <typeparam name="TKey">Primary key type of tables.</typeparam>
  public class Bootstrap<TDbContext, TKey>
    where TDbContext : DbContext
    where TKey : IEquatable<TKey>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Bootstrap{TDbContext, TKey}"/> class.
    /// </summary>
    /// <param name="configuration">Configuration object to use.</param>
    public Bootstrap(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    /// <summary>
    /// Gets the configuration root.
    /// </summary>
    private IConfiguration Configuration { get; }

    /// <summary>
    /// Standard ConfigureServices.
    /// </summary>
    /// <param name="services">Services.</param>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddHttpContextAccessor();
      services
        .AddPublicGraphqlEndpoint(this.Configuration);
    }

    /// <summary>
    /// Standard AppBuilder configuration.
    /// </summary>
    /// <param name="app">ApplicationBuilder instance.</param>
    public void Configure(IApplicationBuilder app)
    {
      app
        .UseAuthentication()
        .UseAuthorization()
        .UseRouting()
        .UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }
  }
}