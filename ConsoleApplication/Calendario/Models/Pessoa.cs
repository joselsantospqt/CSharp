using System;
using System.Collections.Generic;
using System.Text;

namespace Calendario.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string NomeCompleto { get; set; }

        public DateTime DataNascimento { get; set; }

        public void MontaNomeCompleto()
        {
            this.NomeCompleto =  $"{this.Nome} {this.SobreNome}";
        }

    }
}
