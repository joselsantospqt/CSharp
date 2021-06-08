using Calendario.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendario.Repositorio
{
    public class RepositorioPessoa
    {
        private static List<Pessoa> ListaDePessoasCadastradas { get; set; } = new List<Pessoa>();

        public void Adicionar(Pessoa pessoa)
        {
            ListaDePessoasCadastradas.Add(pessoa);
        }

        public List<Pessoa> BuscaPrimeiroNomePessoa(string nome)
        {
            return ListaDePessoasCadastradas.FindAll(x => x.Nome.ToString() == nome);
        }

        public List<Pessoa> BuscaNomeCompletoPessoa(string nomeCompleto)
        {
            return ListaDePessoasCadastradas.FindAll(x => x.Nome.ToString() == nomeCompleto);
        }

    }
}
