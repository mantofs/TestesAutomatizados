using Xunit;

namespace Demo.Tests
{
  public class AssertNullBoolTest
  {
    [Fact]
    public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
    {
      //Arrange And Act
      var func = new Funcionario("", 1000);

      //Asserts
      Assert.False(string.IsNullOrEmpty(func.Nome));
    }

    [Fact]
    public void Funcionario_Nome_NaoDeveTerApelido()
    {
      //Arrange And Act
      var func = new Funcionario("Marcos", 1000);

      //Asserts
      Assert.Null(func.Apelido);

      //Asserts Bool
      Assert.True(string.IsNullOrEmpty(func.Apelido));
      Assert.False(func.Apelido?.Length > 0);
    }
  }
}