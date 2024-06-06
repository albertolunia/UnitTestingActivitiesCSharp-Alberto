using NSubstitute;

namespace Atividade10.Tests;

public class UserManagerTests
{
    [Fact]
    public void FetchUserInfo_QuandoChamado_ChamarGetUserInfo_RetornarUsuario()
    {
        // Arrange
        var userService = Substitute.For<IUserService>();
        var userManager = new UserManager(userService);
        userService.GetUserInfo(1).Returns(new User("Fulano", "fulano@email.com"));

        // Act
        var result = userManager.FetchUserInfo(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Fulano", result.Name);
        Assert.Equal("fulano@email.com", result.Email);
    }
}
