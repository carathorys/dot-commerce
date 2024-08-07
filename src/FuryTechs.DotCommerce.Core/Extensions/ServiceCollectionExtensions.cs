namespace FuryTechs.DotCommerce.Core.Extensions;

using Database;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Extensions for IServiceCollection class.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds GraphQL endpoint to the Service Collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Configuration object.</param>
    /// <returns>Parameterized service collection.</returns>
    public static IRequestExecutorBuilder AddShopAPIEndpoint<TKey>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TKey : IEquatable<TKey>
    {
        return services
            .AddGraphQLServer("shopSchema")
            .AddMutationType<GraphQL.ShopAPI.Mutations>()
            .AddQueryType<GraphQL.ShopAPI.Queries>();
    }

    /// <summary>
    /// Adds GraphQL endpoint to the Service Collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Configuration object.</param>
    /// <returns>Parameterized service collection.</returns>
    public static IRequestExecutorBuilder AddAdminAPIEndpoint<TKey>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TKey : IEquatable<TKey>
    {
        return services
            .AddGraphQLServer("adminSchema")
            .AddMutationType<GraphQL.ShopAPI.Mutations>()
            .AddQueryType<GraphQL.ShopAPI.Queries>();
    }

    /// <summary>
    /// Adds a database context to the Service collection.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <param name="config">Configuration.</param>
    /// <typeparam name="TKey">Primary key for entities.</typeparam>
    /// <typeparam name="TDbContext">Type of the db context.</typeparam>
    /// <returns>Changed IServiceCollection.</returns>
    public static IServiceCollection AddDatabaseContext<TKey, TDbContext>(
        this IServiceCollection services,
        IConfiguration config)
        where TKey : IEquatable<TKey>
        where TDbContext : BaseDbContext<TKey>
    {
        var connectionString = config.GetConnectionString("Default");
        services.AddPostgres<TKey, TDbContext>(connectionString ??
                                               throw new InvalidOperationException(
                                                   "The ConnectionString for 'Default' is not defined!"));
        return services;
    }

    /// <summary>
    /// Adds a database context to the Service collection.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <param name="config">Configuration.</param>
    /// <typeparam name="TDbContext">Type of the db context.</typeparam>
    /// <returns>Changed IServiceCollection.</returns>
    public static IServiceCollection AddDatabaseContext<TDbContext>(
        this IServiceCollection services,
        IConfiguration config)
        where TDbContext : BaseDbContext<int>
    {
        return services.AddDatabaseContext<int, TDbContext>(config);
    }

    private static IServiceCollection AddPostgres<TKey, TDbContext>(
        this IServiceCollection services,
        string connectionString)
        where TKey : IEquatable<TKey>
        where TDbContext : BaseDbContext<TKey>
    {
        services.AddDbContext<TDbContext>(m => m
            .UseNpgsql(connectionString, e => e.MigrationsAssembly(typeof(TDbContext).Assembly.FullName))
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .EnableThreadSafetyChecks());
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        dbContext.Database.Migrate();
        return services;
    }
}