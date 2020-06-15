using System;
using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using Xunit;

namespace Features.Tests.DadosHumanos
{
  [CollectionDefinition(nameof(ClienteDadosHumanosCollection))]
  public class ClienteDadosHumanosCollection : ICollectionFixture<ClienteTestsFixture>
  { }
  public class ClienteTestsFixture : IDisposable
  {
    public Cliente ClienteValido()
    {

      var genero = new Faker().PickRandom<Name.Gender>();

      var cliente = new Faker<Cliente>("pt_BR").CustomInstantiator(f => new Cliente(
      Guid.NewGuid(),
      f.Name.FirstName(genero),
      f.Name.LastName(genero),
      f.Date.Past(80, DateTime.Now.AddYears(-18)),
      DateTime.Now, "", true))
      .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));
      Console.WriteLine(cliente);
      return cliente;
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

    public void Dispose()
    {

    }
  }
}