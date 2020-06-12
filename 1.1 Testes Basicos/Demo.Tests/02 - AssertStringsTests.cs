using Xunit;

namespace Demo.Tests
{
  public class AssertStringsTests
  {
    [Fact]
    public void StringTools_UnirNomes_RetornarNomeCompleto()
    {

      //Arrange
      var sut = new StringTools();

      //Act
      var nomeCompleto = sut.Unir("Marcos", "Silva");

      //Asserts
      Assert.Equal("Marcos Silva", nomeCompleto);

    }

    [Fact]
    public void StringTools_UnirNomes_DeveIgnorarCases()
    {

      //Arrange
      var sut = new StringTools();

      //Act
      var nomeCompleto = sut.Unir("Marcos", "Silva");

      //Asserts
      Assert.Equal("MARCOS SILVA", nomeCompleto, true);

    }

    [Fact]
    public void StringTools_UnirNomes_DeveConterTrecho()
    {

      //Arrange
      var sut = new StringTools();

      //Act
      var nomeCompleto = sut.Unir("Marcos", "Silva");

      //Asserts
      Assert.Contains("cos", nomeCompleto);

    }

    [Fact]
    public void StringTools_UnirNomes_DeveComecarCom()
    {

      //Arrange
      var sut = new StringTools();

      //Act
      var nomeCompleto = sut.Unir("Marcos", "Silva");

      //Asserts
      Assert.StartsWith("Marc", nomeCompleto);

    }

    [Fact]
    public void StringTools_UnirNomes_DeveTerminarCom()
    {

      //Arrange
      var sut = new StringTools();

      //Act
      var nomeCompleto = sut.Unir("Marcos", "Silva");

      //Asserts
      Assert.EndsWith("lva", nomeCompleto);

    }

    [Fact]
    public void StringTools_UnirNomes_ValidarExpressaoRegular()
    {

      //Arrange
      var sut = new StringTools();

      //Act
      var nomeCompleto = sut.Unir("Marcos", "Silva");

      //Asserts
      Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);

    }

  }
}