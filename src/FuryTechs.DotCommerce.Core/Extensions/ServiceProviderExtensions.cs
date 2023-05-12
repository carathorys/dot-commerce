using FuryTechs.DotCommerce.Core.Database;
using FuryTechs.DotCommerce.Core.Database.Identity;
using FuryTechs.DotCommerce.Core.GraphQL;
using FuryTechs.DotCommerce.Core.GraphQL.Identity;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Queries = FuryTechs.DotCommerce.Core.GraphQL.Queries;

namespace FuryTechs.DotCommerce.Core.Extensions
{
  /// <summary>
  /// Extensions for IServiceCollection class.
  /// </summary>
  public static class ServiceProviderExtensions
  {
    /// <summary>
    /// Adds the necessary authentication schemes to the Service Collection
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Configuration object.</param>
    /// <typeparam name="T">Type of the db context.</typeparam>
    /// <returns>Parameterized service collection.</returns>
    public static IServiceCollection AddDotCommerceAuthenticationSchemes<T>(
      this IServiceCollection services,
      IConfiguration
        configuration)
      where T : BaseDbContext
    {
      // var builder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      //   .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
      //     options => configuration.Bind("JwtSettings", options))
      //   .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
      //     options => configuration.Bind("CookieSettings", options));
      // builder
      //   .AddApplicationCookie();
      services.AddIdentity<User, Role>(
          options => configuration.Bind("IdentityOptions", options)
        )
        .AddEntityFrameworkStores<T>()
        ;

      return services;
    }

    /// <summary>
    /// Adds the DB context to the Service Collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Configuration object.</param>
    /// <typeparam name="T">Type of the db context.</typeparam>
    /// <returns>Parameterized service collection.</returns>
    public static IServiceCollection AddDotCommerceDbContext<T>(
      this IServiceCollection services,
      IConfiguration configuration)
      where T : BaseDbContext
    {
      return services
        .AddDbContext<T>(
          x =>
          {
            x.UseNpgsql(configuration.GetConnectionString(
                typeof(T).Name
              ))
              .EnableSensitiveDataLogging(true)
              .EnableDetailedErrors(true)
              .EnableThreadSafetyChecks(true)
              ;
          });
    }

    /// <summary>
    /// Adds GraphQL endpoint to the Service Collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Configuration object.</param>
    /// <typeparam name="T">Type of the db context.</typeparam>
    /// <returns>Parameterized service collection.</returns>
    public static IRequestExecutorBuilder AddDotCommerceGraphqlEndpoints(
      this IServiceCollection services,
      IConfiguration configuration)
    {
      return services
        .AddAuthorization(options =>
        {
          options.AddPolicy("Authenticated", builder => builder.RequireAuthenticatedUser());
        })
        .AddGraphQLServer()
        .AddAuthorization()
        .AddMutationType<Mutations>()
        .AddQueryType<Queries>()
        .AddIdentityExtension();
    }
  }
}