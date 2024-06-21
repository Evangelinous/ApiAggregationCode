using System.Collections.Generic;
using ApiAggregation.Controllers;
using WebApiAggregation.Models;
using WebApiAggregation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class AuthControllerTests
{
    private readonly Mock<ILogger<AuthController>> _loggerMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly Mock<IUserService> _userServiceMock;
    private readonly Mock<IAuthService> _authServiceMock;
    private readonly AuthController _authController;

    public AuthControllerTests()
    {
        _loggerMock = new Mock<ILogger<AuthController>>();
        _configurationMock = new Mock<IConfiguration>();
        _userServiceMock = new Mock<IUserService>();
        _authServiceMock = new Mock<IAuthService>();

        _authController = new AuthController(
            _loggerMock.Object,
            _configurationMock.Object,
            _userServiceMock.Object,
            _authServiceMock.Object
        );

        _configurationMock.Setup(config => config["JwtSettings:SecretKey"]).Returns("your-256-bit-secret");
        _configurationMock.Setup(config => config["JwtSettings:Issuer"]).Returns("your-issuer");
        _configurationMock.Setup(config => config["JwtSettings:Audience"]).Returns("your-audience");
    }

    [Fact]
    public void Login_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var validUser = new UserDataModel { UserName = "user1", Password = "password1", Roles = new List<string> { "User" } };
        _userServiceMock.Setup(service => service.ValidateUser("user1", "password1"))
            .Returns(validUser);

        _authServiceMock.Setup(service => service.GenerateJwtToken(validUser.UserName, validUser.Roles))
            .Returns("fake-jwt-token");

        // Act
        var loginModel = new LoginModel { Username = "user1", Password = "password1" };
        var result = _authController.Login(loginModel);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = okResult.Value.GetType().GetProperty("token").GetValue(okResult.Value, null);
        Assert.Equal("fake-jwt-token", response);
    }


    [Fact]
    public void Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
    {
        // Arrange
        _userServiceMock.Setup(service => service.ValidateUser("invaliduser", "invalidpassword"))
            .Returns((UserDataModel)null);

        // Act
        var loginModel = new LoginModel { Username = "invaliduser", Password = "invalidpassword" };
        var result = _authController.Login(loginModel);

        // Assert
        var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        var response = unauthorizedResult.Value;
        Assert.NotNull(response);
        Assert.Equal(new { message = "Invalid credentials" }.message, response.GetType().GetProperty("message").GetValue(response, null));
    }
}
