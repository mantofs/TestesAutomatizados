using Demo.Enum;
using Xunit;
using Xunit.Abstractions;

namespace Demo.Tests
{
  public class AssertingRangesTests
  {
    [Theory]
    [InlineData(700)]
    [InlineData(2000)]
    [InlineData(7549)]
    [InlineData(8000)]
    [InlineData(12567)]
    [InlineData(20456)]
    public void Funcionario_Salario_FaixasSalariaisDevemRespeitarNivelProfissional(double salario)
    {
      //Arrange And Act
      var func = new Funcionario("Marcos", salario);

      //Asserts
      if (func.NivelProfissional == NivelProfissional.Junior)
      {
        Assert.InRange(func.Salario, 500, 1999);
      }

      if (func.NivelProfissional == NivelProfissional.Pleno)
      {
        Assert.InRange(func.Salario, 2000, 7999);
      }

      if (func.NivelProfissional == NivelProfissional.Senior)
      {
        Assert.InRange(func.Salario, 8000, double.MaxValue);
      }
      Assert.NotInRange(func.Salario, 0, 500);

    }
  }
}