using System;
using System.Collections.Generic;
using Demo.Enum;

namespace Demo
{
  public class Funcionario : Pessoa
  {
    public double Salario { get; private set; }
    public NivelProfissional NivelProfissional { get; private set; }
    public IList<string> Habiliadades { get; private set; }
    public Funcionario(string nome, double salario)
    {
      this.Nome = string.IsNullOrEmpty(nome) ? "Fulano" : nome;

    }

    private void DefinirSalario(double salario)
    {

      if (salario < 500) throw new Exception("Salário inferior ao permitido");

      if (salario > 7999) NivelProfissional = NivelProfissional.Senior;
      else if (salario > 1999) NivelProfissional = NivelProfissional.Pleno;
      else NivelProfissional = NivelProfissional.Junior;

    }

    private void DefinirHabilidades()
    {

      var habilidadesBasicas = new List<string>(){
        "Lógica de Programação",
        "OOP"
      };

      Habiliadades = habilidadesBasicas;


      switch (NivelProfissional)
      {
        case NivelProfissional.Senior:
          Habiliadades.Add("Testes");
          Habiliadades.Add("Microservices");
          break;
        case NivelProfissional.Pleno:
          Habiliadades.Add("Testes");
          break;
      }

    }

  }
}