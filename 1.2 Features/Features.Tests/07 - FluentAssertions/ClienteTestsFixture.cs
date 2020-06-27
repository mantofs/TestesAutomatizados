using System;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using Xunit;
using System.Linq;
using Moq.AutoMock;

namespace Features.Tests.FluentAssertions
{
  [CollectionDefinition(nameof(ClienteDadosHumanosAutoMockFluentAssertionsCollection))]
  public class ClienteDadosHumanosAutoMockFluentAssertionsCollection : ICollectionFixture<ClienteTestsFixture>
  { }
  public class ClienteTestsFixture : IDisposable
  {
    private ClienteService ClienteService;
    public AutoMocker Mocker;
    public IEnumerable<Cliente> Clientes(int quantidade, bool ativo)
    {

      var genero = new Faker().PickRandom<Name.Gender>();

      var clientes = new Faker<Cliente>("pt_BR").CustomInstantiator(f => new Cliente(
      Guid.NewGuid(),
      f.Name.FirstName(genero),
      f.Name.LastName(genero),
      f.Date.Past(80, DateTime.Now.AddYears(-18)),
      DateTime.Now, "", ativo))
      .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));


      return clientes.Generate(quantidade);
    }

    public IEnumerable<Cliente> ClientesVariados()
    {
      var clientes = new List<Cliente>();

      clientes.AddRange(Clientes(50, true));
      clientes.AddRange(Clientes(50, false));

      return clientes;

    }
    public Cliente ClienteValido()
    {

      return Clientes(1, true).FirstOrDefault();

    }
    public Cliente ClienteInvalido()
    {
      var cliente = new Cliente(Guid.NewGuid(),
      "",
      "",
      DateTime.Now,
      DateTime.Now,
      "silvafmarcos",
      true);
      return cliente;
    }

    public ClienteService ObterClienteService()
    {
      Mocker = new AutoMocker();
      ClienteService = Mocker.CreateInstance<ClienteService>();
      return ClienteService;
    }


    public void Dispose()
    {

    }
  }
}