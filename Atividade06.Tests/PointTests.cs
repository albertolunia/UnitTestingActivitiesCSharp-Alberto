namespace Atividade06.Tests;

public class PointTests
{
    [Fact]
    public void DistanceTo_QuandoPontoForNulo_RetornarMensagemDeErro()
    {
        var point = new Point(0, 0);
        var exception = Assert.Throws<ArgumentNullException>(() =>
            point.DistanceTo(null));
        Assert.Equal("Argument must be a Point (Parameter 'other')", exception.Message);
    }

    [Fact]
    public void DistanceTo_QuandoPontoNãoForNulo_RetornarCalculoDaDistancia()
    {
        var point1 = new Point(0, 0);
        var point2 = new Point(3, 4);
        Assert.Equal(5, point1.DistanceTo(point2));
    }
}
