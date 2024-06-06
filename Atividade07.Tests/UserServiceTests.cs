using NSubstitute;

namespace Atividade07.Tests;

public class UserServiceTests
{
    [Fact]
    public void SaveUser_QuandoNomeEmailVazio_RetornarArgumentException()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        var userService = new UserService(db);
        var user = new User(name: "", email: "");

        // Act
        var act = () => userService.SaveUser(user);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void SaveUser_QuandoNomeEmailPreenchido_SalvarUsuario()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        var userService = new UserService(db);
        var user = new User(name: "Fulano", email: "fulano@email.com");

        // Act
        userService.SaveUser(user);

        // Assert
        db.Received(1).SaveUser(user);
    }
}
