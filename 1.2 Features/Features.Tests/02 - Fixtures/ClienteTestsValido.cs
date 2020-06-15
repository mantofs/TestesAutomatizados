using System;
using Features.Clientes;
using Xunit;

namespace Features.Tests.Fixtures
{
  [Collection(nameof(ClienteCollection))]
  public class ClienteTestsValido
  {
    readonly ClienteTestsFixture _clienteTestsFixture;

    public ClienteTestsValido(ClienteTestsFixture clienteTestsFixture)
    {
      _clienteTestsFixture = clienteTestsFixture;
    }

    [Fact(DisplayName = "DeveEstarValido")]
    [Trait("Categoria", "Cliente Fixtures Testes")]
    public void Cliente_NovoCliente_DeveEstarValido()
    {
      //Arrange
      var cliente = _clienteTestsFixture.ClienteValido();

      //Act
      var result = cliente.EhValido();

      //Asserts
      Assert.True(result);
      Assert.Equal(0, cliente.ValidationResult.Errors.Count);

    }
  }
}