namespace FuryTechs.DotCommerce.Core.Tests.Database.Entities.Base;

using FuryTechs.DotCommerce.Core.Database.Entities.Base;
using Xunit;

public class DotCommerceEntityTests
{
    [Fact]
    public void DotCommerceEntity_GuidKey_Initializer_SetsIdToEmptyGuid()
    {
        // Arrange & Act - Create instance with empty constructor
        var entity = new BaseDotCommerceEntity<Guid>();

        // Assert
        Assert.True(Guid.Empty.Equals(entity.Id));
    }

    [Fact]
    public void DotCommerceEntity_IntKey_Initializer_SetsIdToZero()
    {
        // Arrange & Act - Create instance with empty constructor
        var entity = new BaseDotCommerceEntity<int>();

        // Assert
        Assert.Equal(0, entity.Id);
    }

    [Fact]
    public void DotCommerceEntity_AssignsProperties_ToInstance()
    {
        // Arrange
        var guidId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;
        var updatedAt = DateTimeOffset.UtcNow.AddSeconds(1);

        // Act
        var entity = new BaseDotCommerceEntity<Guid>(
            guidId, createdAt, updatedAt);

        // Assert
        Assert.Equal(guidId, entity.Id);
        Assert.Equal(createdAt, entity.CreatedAt);
        Assert.Equal(updatedAt, entity.UpdatedAt);
    }
}
