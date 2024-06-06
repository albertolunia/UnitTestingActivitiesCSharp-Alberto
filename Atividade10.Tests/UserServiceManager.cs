using NSubstitute;

namespace Atividade10.Tests;

public class UserServiceManager
{
    [Fact]
    public void GetUserInfo_QuandoChamado_RetornaUsuario()
    {
        // Arrange
        var userService = Substitute.For<IUserService>();
        var userId = 1;
        userService.GetUserInfo(userId).Returns(new User("Fulano", "fulano@email.com"));

        // Act
        var result = userService.GetUserInfo(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Fulano", result.Name);
        Assert.Equal("fulano@email.com", result.Email);
    }
}
