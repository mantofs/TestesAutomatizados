using System;
using Features.Clientes;
using Xunit;

namespace Features.Tests.Fixtures
{
  [CollectionDefinition(nameof(ClienteCollection))]
  public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
  { }
  public class ClienteTestsFixture : IDisposable
  {
    public Cliente ClienteValido()
    {
      var cliente = new Cliente(Guid.NewGuid(),
      "Marcos",
      "Silva",
      DateTime.Now.AddYears(-31),
      DateTime.Now,
      "silvafmarcos@modularsoftware.com",
      true);
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