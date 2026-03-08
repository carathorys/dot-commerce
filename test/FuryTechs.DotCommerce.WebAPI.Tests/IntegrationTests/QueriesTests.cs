namespace FuryTechs.DotCommerce.WebAPI.Tests.IntegrationTests;

using Xunit;

public class QueriesTests
{
    [Fact]
    public void AdminQueries_Project_ComilesSuccessfully()
    {
        // Arrange - Test that the Admin Queries class compiles correctly
        var type = typeof(FuryTechs.DotCommerce.Core.GraphQL.AdminAPI.Queries);

        // Act & Assert - If we got here, compilation succeeded
        Assert.NotNull(type);
        Assert.IsType<FuryTechs.DotCommerce.Core.GraphQL.AdminAPI.Queries>(type);
    }

    [Fact]
    public void ShopQueries_Project_ComilesSuccessfully()
    {
        // Arrange - Test that the Shop Queries class compiles correctly
        var type = typeof(FuryTechs.DotCommerce.Core.GraphQL.ShopAPI.Queries);

        // Act & Assert - If we got here, compilation succeeded
        Assert.NotNull(type);
        Assert.IsType<FuryTechs.DotCommerce.Core.GraphQL.ShopAPI.Queries>(type);
    }

    [Fact]
    public void ShopMutations_Project_ComilesSuccessfully()
    {
        // Arrange - Test that the Shop Mutations class compiles correctly
        var type = typeof(FuryTechs.DotCommerce.Core.GraphQL.ShopAPI.Mutations);

        // Act & Assert - If we got here, compilation succeeded
        Assert.NotNull(type);
        Assert.IsType<FuryTechs.DotCommerce.Core.GraphQL.ShopAPI.Mutations>(type);
    }
}
