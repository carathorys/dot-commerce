// <copyright file="Bootstrap.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core;

using FuryTechs.DotCommerce.Core.Database;
using FuryTechs.DotCommerce.Core.Database.Entities.Identity;
using FuryTechs.DotCommerce.Core.Extensions;
using FuryTechs.DotCommerce.Core.GraphQL.Identity;
using FuryTechs.DotCommerce.Identity.GraphQL;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Temporary class to help bootstrapping application.
/// </summary>
/// <typeparam name="TKey">Primary key type of tables.</typeparam>
public class Bootstrap<TKey, TDbContext>
    where TKey : IEquatable<TKey>
    where TDbContext : BaseDbContext
{
    private WebApplication app;

    /// <summary>
    /// Initializes a new instance of the <see cref="Bootstrap{TKey}"/> class.
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
        services.AddIdentity<User<TKey>, Role<TKey>>()
            .AddRoleManager<RoleManager<Role<TKey>>>()
            .AddSignInManager()
            .AddEntityFrameworkStores<TDbContext>();
        services.AddAuthorization()
            .AddAuthentication()
            .AddJwtBearer();
        services.AddHttpContextAccessor();
        services.AddDatabaseContext<TDbContext>(this.Configuration);
        services
          .AddPublicGraphqlEndpoint(this.Configuration)
          .AddIdentity<TKey>();
    }

    /// <summary>
    /// Standard AppBuilder configuration.
    /// </summary>
    /// <param name="app">ApplicationBuilder instance.</param>
    public void Configure(WebApplication app)
    {
        this.app = app;
        this.app
          .UseAuthentication()
          .UseAuthorization()
          .UseRouting()
          .UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }

    public void Run()
    {
        this.app.Run();
    }
}