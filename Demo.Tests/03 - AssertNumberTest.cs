using Xunit;

namespace Demo.Tests
{
  public class AssertNumberTest
  {
    [Fact]
    public void Calculadora_Somar_DeveSerIgual()
    {
      //Arrange
      var calc = new Calculadora();

      //Act
      var result = calc.Somar(1, 2);

      //Asserts
      Assert.Equal(3, result);
    }

    [Fact]
    public void Calculadora_Somar_NaoDeveSerIgual()
    {
      // Arrange
      var calculadora = new Calculadora();

      // Act
      var retorno = calculadora.Somar(1.12123123, 2.23123123);

      // Assert
      Assert.NotEqual(3.3, retorno, 1);
    }
  }
}