using System.Collections.Generic;

namespace Features.Core
{
  public interface IRepository<T>
  {
    IEnumerable<T> ObterTodos();
    void Adicionar(T t);
    void Atualizar(T t);
    void Remover(T t);

    void Dispose();
  }
}