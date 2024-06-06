namespace Atividade08.Tests;

public class StatisticsTests
{
    [Fact]
    public void CalculateAverage_QuandoListaVazia_RertornaArgumentException()
    {
        // Arrange
        var statistics = new Statistics();
        var numbers = new List<int>();

        // Act
        Action act = () => statistics.CalculateAverage(numbers);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void CalculateAverage_QuandoListaTemElemento_RertornaQuantidade()
    {
        // Arrange
        var statistics = new Statistics();
        var numbers = new List<int> { 1 };

        // Act
        var result = statistics.CalculateAverage(numbers);

        // Assert
        Assert.Equal(1, result);
    }
}
