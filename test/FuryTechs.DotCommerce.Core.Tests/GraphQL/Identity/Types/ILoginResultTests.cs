namespace FuryTechs.DotCommerce.Core.Tests.GraphQL.Identity.Types;

using Xunit;
using static FuryTechs.DotCommerce.Core.GraphQL.Identity.Types.ILoginResult;

public class ILoginResultExtensionsTests
{
    [Fact]
    public void LoginSuccess_Ctor_SetsCorrectTypeAndProperties()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var firstName = "Jane";
        var lastName = "Smith";
        var email = "jane.smith@example.com";

        // Act
        var loginSuccess = ILoginResult.LoginSuccess(userId, firstName, lastName, email);

        // Assert
        Assert.Equal(LoginResultType.Success, loginSuccess.Type);
        Assert.IsType<CurrentUser>(loginSuccess.Union);
        Assert.Equal(userId, ((CurrentUser)loginSuccess.Union).Id);
        Assert.Equal(firstName, ((CurrentUser)loginSuccess.Union).FirstName);
        Assert.Equal(lastName, ((CurrentUser)loginSuccess.Union).LastName);
        Assert.Equal(email, ((CurrentUser)loginSuccess.Union).Email);
    }

    [Fact]
    public void LoginFailed_Ctor_SetsCorrectTypeAndProperties()
    {
        // Arrange
        var errorCode = "InvalidCredentials";
        var errorMessage = "Invalid credentials provided.";
        var errorDataKey = "UsernameError";

        // Act
        var loginFailed = ILoginResult.LoginFailed(errorCode, errorMessage, errorDataKey);

        // Assert
        Assert.Equal(LoginResultType.Failed, loginFailed.Type);
        Assert.IsType<LoginFailed>(loginFailed.Union);
        Assert.Equal(errorCode, ((LoginFailed)loginFailed.Union).ErrorCode);
        Assert.Equal(errorMessage, ((LoginFailed)loginFailed.Union).ErrorMessage);
        Assert.Equal("EmptyString", ((LoginFailed)loginFailed.Union).ErrorData.Key);
    }
}
