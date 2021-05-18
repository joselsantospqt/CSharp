using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_entrega.Entity
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }

        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }

        public TipoEnderecoEnum TipoEndereco { get; set; }

    }
}
