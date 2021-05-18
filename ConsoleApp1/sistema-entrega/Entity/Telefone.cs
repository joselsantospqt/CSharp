using System;
using System.Collections.Generic;
using System.Text;

namespace sistema_entrega.Entity
{
    public class Telefone
    {

        public string DDD { get; set; }
        public string DDI { get; set; }
        public string Fixo { get; set; }
        public string Celular { get; set; }
        public string Ramal { get; set; }

        public TipoContatoEnum TipoContato { get; set; }

    }
}
