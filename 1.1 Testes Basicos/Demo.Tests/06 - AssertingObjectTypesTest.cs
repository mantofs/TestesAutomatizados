using Xunit;

namespace Demo.Tests
{
  public class AssertingObjectTypesTest
  {

    [Fact]
    public void Funcionario_Criar_DeveRetornarTipoFuncionario()
    {
      //Arrange And Act
      var func = FuncionarioFactory.Criar("", 1000);
      //Asserts
      Assert.IsType<Funcionario>(func);
    }

    [Fact]
    public void Funcionario_Criar_DeveRetornarTipoDerivadoPessoa()
    {
      //Arrange And Act
      var func = FuncionarioFactory.Criar("", 1000);

      //Asserts

      Assert.IsAssignableFrom<Pessoa>(func);
    }


  }
}