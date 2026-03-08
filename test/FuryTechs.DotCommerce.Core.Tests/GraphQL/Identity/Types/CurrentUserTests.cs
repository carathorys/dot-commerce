namespace FuryTechs.DotCommerce.Core.Tests.GraphQL.Identity.Types;

using FuryTechs.DotCommerce.Core.GraphQL.Identity.Types;
using Xunit;

public class CurrentUserTests
{
    [Fact]
    public void CurrentUser_Ctor_SetsPropertiesCorrectly()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@example.com";

        // Act
        var currentUser = new CurrentUser(userId, firstName, lastName, email);

        // Assert
        Assert.Equal(userId, currentUser.Id);
        Assert.Equal(firstName, currentUser.FirstName);
        Assert.Equal(lastName, currentUser.LastName);
        Assert.Equal(email, currentUser.Email);
    }
}
