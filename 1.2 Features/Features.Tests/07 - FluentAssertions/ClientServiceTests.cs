using System.Linq;
using System.Threading;
using Features.Clientes;
using FluentAssertions;
using MediatR;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Features.Tests.FluentAssertions
{
  [Collection(nameof(ClienteDadosHumanosAutoMockFluentAssertionsCollection))]
  public class ClientServiceTests
  {
    readonly ClienteTestsFixture _clienteTestFixture;
    readonly ClienteService _clienteService;
    public ClientServiceTests(ClienteTestsFixture clienteTestFixture)
    {
      _clienteTestFixture = clienteTestFixture;
      _clienteService = _clienteTestFixture.ObterClienteService();
    }

    [Fact(DisplayName = "Deve Estar Valido")]
    [Trait("Categoria", "Cliente Fluent Assertions Testes")]
    public void Cliente_NovoCliente_DeveEstarValido()
    {
      //Arrange
      var cliente = _clienteTestFixture.ClienteValido();

      //Act
      var result = cliente.EhValido();

      //Asserts
      //Assert.True(result);
      //Assert.Equal(0, cliente.ValidationResult.Errors.Count);

      result.Should().BeTrue();
      cliente.ValidationResult.Errors.Should().HaveCount(0);

    }

    [Fact(DisplayName = "Deve Estar Inv'a'lido")]
    [Trait("Categoria", "Cliente Fluent Assertions Testes")]
    public void Cliente_NovoCliente_DeveEstarInvalido()
    {
      //Arrange
      var cliente = _clienteTestFixture.ClienteInvalido();

      //Act
      var result = cliente.EhValido();

      //Asserts
      //Assert.True(result);
      //Assert.Equal(0, cliente.ValidationResult.Errors.Count);

      result.Should().BeFalse();
      cliente.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1, "Deve possuir erros de validação");

    }

  }
}