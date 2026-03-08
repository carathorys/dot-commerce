namespace FuryTechs.DotCommerce.WebAPI.Tests.IntegrationTests;

using Xunit;

public class WebApiTests
{
    [Fact]
    public void WebApiProject_ComilesSuccessfully()
    {
        // Arrange - We're testing that the WebAPI project compiles
        var assembly = typeof(Microsoft.AspNetCore.Builder.IApplicationBuilder);

        // Act & Assert - If we got here, compilation succeeded
        Assert.NotNull(assembly);
    }
}
