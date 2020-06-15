using System;
using Features.Clientes;
using Xunit;

namespace Features.Tests.Fixtures
{
  [Collection(nameof(ClienteCollection))]
  public class ClienteTestInvalido
  {
    readonly ClienteTestsFixture _clienteTestsFixture;

    public ClienteTestInvalido(ClienteTestsFixture clienteTestsFixture)
    {
      _clienteTestsFixture = clienteTestsFixture;
    }

    [Fact(DisplayName = "DeveEstarInvalido")]
    [Trait("Categoria", "Cliente Fixtures Testes")]
    public void Cliente_NovoCliente_DeveEstarInvalido()
    {
      //Arrange
      var cliente = _clienteTestsFixture.ClienteInvalido();

      //Act
      var result = cliente.EhValido();

      //Asserts
      Assert.False(result);
      Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);

    }
  }
}