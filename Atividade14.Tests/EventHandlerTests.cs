using NSubstitute;

namespace Atividade14.Tests;

public class EventHandlerTests
{
    [Fact]
    public void HandleEvent_QuandoChamado_EnviarEmail()
    {
        // Arrange
        var emailService = Substitute.For<IEmailService>();
        var eventHandler = new EventHandler(emailService);
        var eventMessage = "Test message";

        // Act
        eventHandler.HandleEvent(eventMessage);

        // Assert
        emailService.ReceivedWithAnyArgs().SendEmail("teste@email.com", "Event Occurred", eventMessage);
    }
}
