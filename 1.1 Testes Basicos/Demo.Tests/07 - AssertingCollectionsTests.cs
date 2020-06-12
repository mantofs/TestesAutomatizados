using Xunit;

namespace Demo.Tests
{
  public class AssertingCollectionsTests
  {
    [Fact]
    public void Funcionario_Habiliadades_NaoDevePossuirHabilidadesVazias()
    {
      //Arrange And Act
      var func = FuncionarioFactory.Criar("Marcos", 10000);

      //Asserts
      Assert.All(func.Habiliadades
      , habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));

    }

    [Fact]
    public void Funcionario_Habiliadades_JuniorDevePossuirHabilidadeBasica()
    {
      //Arrange And Act
      var func = FuncionarioFactory.Criar("Marcos", 1000);

      //Asserts
      Assert.Contains("OOP", func.Habiliadades);

    }

    [Fact]
    public void Funcionario_Habiliadades_JuniorNaoDevePossuirHabilidadeAvancada()
    {
      //Arrange And Act
      var func = FuncionarioFactory.Criar("Marcos", 1000);

      //Asserts
      Assert.DoesNotContain("Microservices", func.Habiliadades);

    }

    [Fact]
    public void Funcionario_Habiliadades_SeniorDevePossuirTodasHabilidades()
    {
      //Arrange And Act
      var func = FuncionarioFactory.Criar("Marcos", 10000);

      var habilidades = new[]
      {
        "Lógica de Programação",
        "OOP",
        "Testes",
        "Microservices"
      };

      //Asserts
      Assert.Equal(habilidades, func.Habiliadades);

    }
  }
}