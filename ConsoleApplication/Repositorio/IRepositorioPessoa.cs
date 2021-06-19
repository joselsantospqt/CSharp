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
        Pessoa GetPessoa(int id);
        List<Pessoa> GetAll();

    }
}
