using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendario.Repositorio
{
    public interface IRepositorioPessoa { 

        void Create(Pessoa pessoa);
        void Update(Pessoa pessoa, int id);
        void Delete(Pessoa pessoa);
        Pessoa GetById(int id);
        List<Pessoa> GetByName(string nome);
        List<Pessoa> GetAll();

    }
}
