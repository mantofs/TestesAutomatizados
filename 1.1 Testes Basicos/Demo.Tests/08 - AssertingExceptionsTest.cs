using System;
using Xunit;

namespace Demo.Tests
{
  public class AssertingExceptionsTest
  {
    [Fact]
    public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
    {
      //Arrange

      var calculadora = new Calculadora();
      //Act And Assert
      Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(100, 0));

    }

    [Fact]
    public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
    {
      //Arrange, Act And Assert
      var exception =
            Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Marcos", 250));

      Assert.Equal("Salário inferior ao permitido", exception.Message);

    }
  }
}