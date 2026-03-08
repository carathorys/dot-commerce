namespace FuryTechs.DotCommerce.Core.Tests.Plugins;

using FuryTechs.DotCommerce.Core.Plugins;
using Xunit;

public class IDotCommercePluginTests
{
    [Fact]
    public void IdotCommercePlugin_NullName_ThrowsArgumentNullException()
    {
        // Assert - Expecting exception when Name is null
        var exception = Assert.Throws<ArgumentNullException>(() => new DotCommerceMockPlugin(null!));
        Assert.Equal(nameof(IDotCommercePlugin.Name), exception.ParamName);
    }

    [Fact]
    public void IdotCommercePlugin_EmptyName_ThrowsArgumentException()
    {
        // Assert - Expecting exception when Name is empty
        var exception = Assert.Throws<ArgumentException>(() => new DotCommerceMockPlugin(string.Empty));
        Assert.Equal(nameof(IDotCommercePlugin.Name), exception.ParamName);
    }

    [Fact]
    public void IdotCommercePlugin_InitializePlugin_ReturnsVoid()
    {
        // Arrange
        string name = "TestPlugin";
        var plugin = new DotCommerceMockPlugin(name);
        IServiceCollection services = new ServiceCollection();
        IConfiguration configuration = new ConfigurationBuilder().Build();

        // Act - Should not throw
        var exceptionInfo = Record.Exception(() => plugin.InitializePlugin(services, configuration));
        
        // Assert - No exception should be thrown by base implementation
        Assert.Null(exceptionInfo);
    }

    [Fact]
    public void IdotCommercePlugin_SetupApplication_ReturnsVoid()
    {
        // Arrange
        string name = "TestPlugin";
        var plugin = new DotCommerceMockPlugin(name);
        IApplicationBuilder app = ApplicationBuilder.Create();

        // Act - Should not throw
        var exceptionInfo = Record.Exception(() => plugin.SetupApplication(app));
        
        // Assert - No exception should be thrown by base implementation
        Assert.Null(exceptionInfo);
    }
}
