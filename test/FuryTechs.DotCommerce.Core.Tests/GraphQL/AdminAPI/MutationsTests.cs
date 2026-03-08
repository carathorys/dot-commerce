namespace FuryTechs.DotCommerce.Core.Tests.GraphQL.AdminAPI;

using Xunit;

public class MutationsTests
{
    [Fact]
    public void Mutations_Ctor_ReturnsNotNullInstance()
    {
        // Act
        var mutations = new Mutations();

        // Assert
        Assert.NotNull(mutations);
    }
}
