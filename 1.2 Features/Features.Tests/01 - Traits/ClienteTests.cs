using System;
using Features.Clientes;
using Xunit;

namespace Features.Tests.Traits
{
  public class ClienteTests
  {
    [Fact(DisplayName = "DeveEstarValido")]
    [Trait("Categoria", "Cliente Trait Testes")]
    public void Cliente_NovoCliente_DeveEstarValido()
    {
      //Arrange
      var cliente = new Cliente(Guid.NewGuid(),
      "Marcos",
      "Silva",
      DateTime.Now.AddYears(-31),
      DateTime.Now,
      "silvafmarcos@modularsoftware.com",
      true);

      //Act
      var result = cliente.EhValido();

      //Asserts
      Assert.True(result);
      Assert.Equal(0, cliente.ValidationResult.Errors.Count);

    }

    [Fact(DisplayName = "DeveEstarInvalido")]
    [Trait("Categoria", "Cliente Trait Testes")]
    public void Cliente_NovoCliente_DeveEstarInvalido()
    {
      //Arrange
      var cliente = new Cliente(Guid.NewGuid(),
      "",
      "",
      DateTime.Now,
      DateTime.Now,
      "silvafmarcos",
      true);

      //Act
      var result = cliente.EhValido();

      //Asserts
      Assert.False(result);
      Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);

    }
  }
}