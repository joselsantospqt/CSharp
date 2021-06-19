using Calendario.Repositorio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Service
{
    public class PessoaService
    {
        public void Create(Pessoa pessoa)
        {
            var PessoaRepository = new RepositorioPessoa();
            PessoaRepository.Create(pessoa);
        }
        public void Delete(Pessoa pessoa)
        {
            var PessoaRepository = new RepositorioPessoa();
            PessoaRepository.Delete(pessoa);
        }
        public void Update(Pessoa pessoa, int id)
        {
            var PessoaRepository = new RepositorioPessoa();
            PessoaRepository.Update(pessoa, id);
        }
        public List<Pessoa> GetAll()
        {
            var PessoaRepository = new RepositorioPessoa();
            return PessoaRepository.GetAll();
        }
        //public Pessoa GetPessoa(int id)
        //{
        //    var PessoaRepository = new RepositorioPessoa();
        //    return PessoaRepository.GetPessoa(id);
        //}
       

    }
}
