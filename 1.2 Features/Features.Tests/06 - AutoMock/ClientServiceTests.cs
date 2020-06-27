using System.Linq;
using System.Threading;
using Features.Clientes;
using MediatR;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Features.Tests.AutoMock
{
  [Collection(nameof(ClienteDadosHumanosAutoMockCollection))]
  public class ClientServiceTests
  {
    readonly ClienteTestsFixture _clienteTestFixture;
    readonly ClienteService _clienteService;
    public ClientServiceTests(ClienteTestsFixture clienteTestFixture)
    {
      _clienteTestFixture = clienteTestFixture;
      _clienteService = _clienteTestFixture.ObterClienteService();
    }

    [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
    [Trait("Categoria", "Cliente Service AutoMock Tests")]
    public void ClientService_Adicionar_DeveExecutarComSucesso()
    {
      //Arrange
      var cliente = _clienteTestFixture.ClienteValido();

      //Act
      _clienteService.Adicionar(cliente);

      //Assert
      _clienteTestFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once);
      _clienteTestFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);

    }
    [Fact(DisplayName = "Adicionar Cliente com Falha")]
    [Trait("Categoria", "Cliente Service AutoMock Tests")]
    public void ClientService_Adicionar_DeveFalharDevidoClienteInvalido()
    {
      //Arrange
      var cliente = _clienteTestFixture.ClienteInvalido();

      //Act
      _clienteService.Adicionar(cliente);

      //Assert
      _clienteTestFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Never);
      _clienteTestFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);

    }

    [Fact(DisplayName = "Obter Clientes Ativos")]
    [Trait("Categoria", "Cliente Service AutoMock Tests")]
    public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
    {
      //Arrange
      _clienteTestFixture.Mocker.GetMock<IClienteRepository>()
      .Setup(c => c.ObterTodos()).Returns(_clienteTestFixture.ClientesVariados());

      //Act
      var clientes = _clienteService.ObterTodosAtivos();

      //Assert
      _clienteTestFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);

      Assert.True(clientes.Any());
      Assert.False(clientes.Count(c => !c.Ativo) > 0);

    }

  }
}