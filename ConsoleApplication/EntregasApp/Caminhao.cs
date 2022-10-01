using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasApp
{
    public class Caminhao
    {
        protected int topoItem = -1;
        protected int topoLocal = -1;
        public string PLACA { get; set; }
        public Local[] LOCAL_ENTREGA = new Local[20];
        public ItemEntrega[] ITENS_ENTREGA = new ItemEntrega[20];

        #region Item
        public void PushItem(ItemEntrega obj)
        {
            if (ITENS_ENTREGA != null && ITENS_ENTREGA.Length != 0 && topoItem == ITENS_ENTREGA.Length - 1)
                Console.WriteLine($"Caminhão : {PLACA} - Caçamba Cheia");
            else
            {
                if (ITENS_ENTREGA.Length == 0)
                    ITENS_ENTREGA = new ItemEntrega[20];
                topoItem++;
                ITENS_ENTREGA[topoItem] = obj;
            }
        }

        public void PopItem(ItemEntrega obj)
        {
            if (ITENS_ENTREGA.Length == 0 || topoItem == -1)
                throw new InvalidOperationException("Caçamba Vazia");
            var list = ITENS_ENTREGA.ToList();
            list.Remove(obj);
            ITENS_ENTREGA = list.ToArray();
            topoItem--;
        }

        public bool TemEspaco()
        {
            var count = ITENS_ENTREGA.Where(x => x != null).ToList();
            if (ITENS_ENTREGA.Count() - count.Count == 0)
                return false;
            else
                return true;
        }

        public int QtdEspacoVazio()
        {
            var count = ITENS_ENTREGA.Where(x => x != null).ToList();
            return ITENS_ENTREGA.Count() - count.Count;
        }

        #endregion

        #region Local
        public void PushLocal(Local obj)
        {
            if (LOCAL_ENTREGA != null && LOCAL_ENTREGA.Length != 0 && topoLocal == LOCAL_ENTREGA.Length - 1)
                Console.WriteLine($"Caminhão : {PLACA} - Atingiu o limite de locais para entrega");
            if (LOCAL_ENTREGA.Length == 0)
                LOCAL_ENTREGA = new Local[20];
            topoLocal++;
            LOCAL_ENTREGA[topoLocal] = obj;

            obj.ITENS_ENTREGA.ForEach(x => PushItem(x));
        }

        public void PopUltimoLocal()
        {
            if (LOCAL_ENTREGA.Length == 0 || topoLocal == -1)
                throw new InvalidOperationException("Caçamba Vazia");
            Local result = LOCAL_ENTREGA.Last();
            LOCAL_ENTREGA = LOCAL_ENTREGA.SkipLast(1).ToArray();
            topoLocal--;
            result.ITENS_ENTREGA.ForEach(x => PopItem(x));
        }


        public void Print()
        {
            var listLocalEntrega = LOCAL_ENTREGA.Where(y => y != null).ToList();
            foreach (var locais in listLocalEntrega)
            {
                Console.WriteLine($"Visitado ponto de entrega {locais.NM_NOME}. Foram entregues os itens: \n");
                locais.ITENS_ENTREGA.ForEach(x => Console.WriteLine($"{x.NM_NOME} \n"));
            }
        }

        #endregion

    }
}
