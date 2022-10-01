using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasApp
{
    public class Local
    {
        public int ID { get; set; }
        public string NM_NOME { get; set; }
        public List<ItemEntrega> ITENS_ENTREGA = new List<ItemEntrega>();

        public ItemEntrega PrimeiroDaLista()
        {
            return ITENS_ENTREGA.First();
        }
    }
}
