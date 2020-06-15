using Xunit;

namespace Features.Tests.Order
{
  [TestCaseOrderer("Features.Tests.Order.PriorityOrderer", "Features.Tests")]
  public class OrderTests
  {
    public static bool Teste1Chamado;
    public static bool Teste2Chamado;
    public static bool Teste3Chamado;
    public static bool Teste4Chamado;

    [Fact(DisplayName = "Teste4"), TestPriority(3)]
    [Trait("Categoria", "Ordenação Testes")]
    public void Teste4()
    {
      Teste4Chamado = true;
      Assert.True(Teste3Chamado);
      Assert.True(Teste1Chamado);
      Assert.False(Teste2Chamado);
    }
    [Fact(DisplayName = "Teste1"), TestPriority(2)]
    [Trait("Categoria", "Ordenação Testes")]
    public void Teste1()
    {
      Teste1Chamado = true;
      Assert.True(Teste3Chamado);
      Assert.False(Teste4Chamado);
      Assert.False(Teste2Chamado);
    }

    [Fact(DisplayName = "Teste3"), TestPriority(1)]
    [Trait("Categoria", "Ordenação Testes")]
    public void Teste3()
    {
      Teste3Chamado = true;
      Assert.False(Teste4Chamado);
      Assert.False(Teste1Chamado);
      Assert.False(Teste2Chamado);
    }
    [Fact(DisplayName = "Teste2"), TestPriority(4)]
    [Trait("Categoria", "Ordenação Testes")]
    public void Teste2()
    {
      Teste2Chamado = true;
      Assert.True(Teste3Chamado);
      Assert.True(Teste1Chamado);
      Assert.True(Teste4Chamado);
    }
  }
}