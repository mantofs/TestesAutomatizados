using MediatR;

namespace Features.Clientes
{
  public class ClienteEmailNotification : INotification
  {
    private string Origem;
    private string Email;

    public ClienteEmailNotification(string origem, string email)
    {
      Origem = origem;
      Email = email;
    }
  }
}