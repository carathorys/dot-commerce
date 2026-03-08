namespace FuryTechs.DotCommerce.WebAPI.Tests.IntegrationTests;

using Xunit;

public class MutationTests
{
    [Fact]
    public void Mutations_Project_ComilesSuccessfully()
    {
        // Arrange - Test that the Mutations class compiles correctly
        var type = typeof(FuryTechs.DotCommerce.Core.GraphQL.AdminAPI.Mutations);

        // Act & Assert - If we got here, compilation succeeded
        Assert.NotNull(type);
        Assert.IsType<FuryTechs.DotCommerce.Core.GraphQL.AdminAPI.Mutations>(type);
    }

    [Fact]
    public void Mutations_Instance_ReturnsNotNull()
    {
        // Arrange
        var mutations = new FuryTechs.DotCommerce.Core.GraphQL.AdminAPI.Mutations();

        // Assert
        Assert.NotNull(mutations);
    }
}
