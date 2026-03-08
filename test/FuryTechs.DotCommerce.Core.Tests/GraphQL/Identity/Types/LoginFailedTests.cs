namespace FuryTechs.DotCommerce.Core.Tests.GraphQL.Identity.Types;

using FuryTechs.DotCommerce.Core.GraphQL.Identity.Types;
using Xunit;

public class LoginFailedTests
{
    [Fact]
    public void LoginFailed_Ctor_SetsErrorCode_Success()
    {
        // Arrange
        var errorCode = "InvalidCredentials";
        var errorMessage = "The username or password is incorrect.";
        var errorDataKey = "UsernameError";

        // Act
        var loginFailed = new LoginFailed(errorCode, errorMessage, errorDataKey);

        // Assert
        Assert.Equal(errorCode, loginFailed.ErrorCode);
        Assert.Equal(errorMessage, loginFailed.ErrorMessage);
        Assert.Equal(errorDataKey, loginFailed.ErrorData.Key);
    }

    [Fact]
    public void LoginFailed_Ctor_WithNullErrorData_Key_SetsEmptyString()
    {
        // Arrange
        var errorCode = "TokenExpired";
        var errorMessage = "Your authentication token has expired.";
        string? errorDataKey = null;

        // Act
        var loginFailed = new LoginFailed(errorCode, errorMessage, errorDataKey);

        // Assert
        Assert.Equal("EmptyString", loginFailed.ErrorData.Key);
    }
}
