// <copyright file="ServiceProviderExtensions.cs" company="FuryTechs">
// Copyright (c) FuryTechs. All rights reserved.
// </copyright>

namespace FuryTechs.DotCommerce.Core.Extensions;

using FuryTechs.DotCommerce.Core.Database;
using FuryTechs.DotCommerce.Core.GraphQL;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Extensions for IServiceCollection class.
/// </summary>
public static class ServiceProviderExtensions
{
  /// <summary>
  /// Adds the DB context to the Service Collection.
  /// </summary>
  /// <param name="services">Service collection.</param>
  /// <param name="configuration">Configuration object.</param>
  /// <typeparam name="TDbContext">Type of the db context.</typeparam>
  /// <returns>Parameterized service collection.</returns>
  public static IServiceCollection AddDotCommerceDbContext<TDbContext>(
    this IServiceCollection services,
    IConfiguration configuration)
    where TDbContext : BaseDbContext
  {
    return services
      .AddDbContext<TDbContext>(
        x =>
        {
          x
            .UseNpgsql(configuration.GetConnectionString(typeof(TDbContext).Name))
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .EnableThreadSafetyChecks();
        });
  }

  /// <summary>
  /// Adds GraphQL endpoint to the Service Collection.
  /// </summary>
  /// <param name="services">Service collection.</param>
  /// <param name="configuration">Configuration object.</param>
  /// <returns>Parameterized service collection.</returns>
  public static IRequestExecutorBuilder AddPublicGraphqlEndpoint(
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
      .AddQueryType<Queries>();
  }
}