using Xunit;

namespace Demo.Tests
{
  public class CalculadoraTests
  {
    [Fact]
    public void Calculadora_Somar_RetornaValoresSoma()
    {
      // Arrange
      var calculadora = new Calculadora();

      // Act
      var retorno = calculadora.Somar(2, 2);

      // Assert
      Assert.Equal(4, retorno);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(3, 2, 5)]
    [InlineData(7, 3, 10)]
    [InlineData(3, -2, 1)]
    public void Calculadora_Somar_RetornaValoresSomaCorretos(double v1, double v2, double total)
    {
      // Arrange
      var calculadora = new Calculadora();

      // Act
      var retorno = calculadora.Somar(v1, v2);

      // Assert
      Assert.Equal(total, retorno);
    }
  }
}