namespace Atividade11.Tests;

public class CustomSorterTests
{
    [Fact]
    public void SortDescending_QuandoChamado_RetornarListaInteirosOrdemDecrescente()
    {
        // Arrange
        var sorter = new CustomSorter();
        var numbers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };

        // Act
        var result = sorter.SortDescending(numbers);

        // Assert
        Assert.Equal(new List<int> { 9, 6, 5, 5, 5, 4, 3, 3, 2, 1, 1 }, result);
    }
}
