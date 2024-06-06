namespace Atividade13.Tests;

public class FactorialCalculatorTests
{
    [Fact]
    public void Calculate_ParametroMenorQueZero_RetornaArgumentException()
    {
        // Arrange
        var calculator = new FactorialCalculator();

        // Act
        var exception = Assert.Throws<ArgumentException>(() => calculator.Calculate(-1));

        // Assert
        Assert.Equal("Number must be non-negative", exception.Message);
    }
}
