using System.Linq;
using System.Threading;
using Features.Clientes;
using MediatR;
using Moq;
using Xunit;

namespace Features.Tests.Mock
{
  [Collection(nameof(ClienteDadosHumanosMockCollection))]
  public class ClientServiceTests
  {
    readonly ClienteTestsFixture _clienteTestFixture;

    public ClientServiceTests(ClienteTestsFixture clienteTestFixture)
    {
      _clienteTestFixture = clienteTestFixture;
    }

    [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
    [Trait("Categoria", "Cliente Service Mock Tests")]
    public void ClientService_Adicionar_DeveExecutarComSucesso()
    {
      //Arrange
      var cliente = _clienteTestFixture.ClienteValido();
      var clienteRepo = new Mock<IClienteRepository>();
      var mediatr = new Mock<IMediator>();

      var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

      //Act
      clienteService.Adicionar(cliente);

      //Assert
      clienteRepo.Verify(r => r.Adicionar(cliente), Times.Once);
      mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);

    }
    [Fact(DisplayName = "Adicionar Cliente com Falha")]
    [Trait("Categoria", "Cliente Service Mock Tests")]
    public void ClientService_Adicionar_DeveFalharDevidoClienteInvalido()
    {
      //Arrange
      var cliente = _clienteTestFixture.ClienteInvalido();
      var clienteRepo = new Mock<IClienteRepository>();
      var mediatr = new Mock<IMediator>();

      var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

      //Act
      clienteService.Adicionar(cliente);

      //Assert
      clienteRepo.Verify(r => r.Adicionar(cliente), Times.Never);
      mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);

    }

    [Fact(DisplayName = "Obter Clientes Ativos")]
    [Trait("Categoria", "Cliente Service Mock Tests")]
    public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
    {
      //Arrange
      var clienteRepo = new Mock<IClienteRepository>();
      var mediatr = new Mock<IMediator>();

      clienteRepo.Setup(c => c.ObterTodos()).Returns(_clienteTestFixture.ClientesVariados());

      var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

      //Act
      var clientes = clienteService.ObterTodosAtivos();

      //Assert
      clienteRepo.Verify(r => r.ObterTodos(), Times.Once);

      Assert.True(clientes.Any());
      Assert.False(clientes.Count(c => !c.Ativo) > 0);

    }

  }
}