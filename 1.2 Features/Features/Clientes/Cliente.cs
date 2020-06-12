using System;
using Features.Core;

namespace Features.Clientes
{
  public class Cliente : Entity
  {
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public string Email { get; private set; }
    public bool Ativo { get; private set; }

    protected Cliente() { }

    public Cliente(Guid id, string nome, string sobrenome, DateTime dataNascimento, DateTime dataCadastro, string email, bool ativo)
    {
      Id = id;
      Nome = nome;
      Sobrenome = sobrenome;
      DataNascimento = dataNascimento;
      DataCadastro = dataCadastro;
      Email = email;
      Ativo = ativo;
    }

    public string NomeCompleto()
    {
      return $"{Nome} {Sobrenome}";
    }
    public bool EhEspecial()
    {
      return DataCadastro < DateTime.Now.AddYears(-3) && Ativo;
    }

    public void Inativar()
    {
      Ativo = false;
    }

    public override bool EhValido()
    {
      ValidationResult = new ClienteValidacao().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}