using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFilaXPilha
{
    public class Pilha
    {
        protected int[] pilha = new int[10];
        protected int topo = -1;

        public void Push(int obj)
        {
            if (pilha != null && pilha.Length != 0 && topo == pilha.Length - 1)
                throw new InvalidOperationException("Pilha Cheia");
            if (pilha.Length == 0)
                pilha = new int[10];
            topo++;
            pilha[topo] = obj;
        }

        public int Pop()
        {
            if (pilha.Length == 0 || topo == -1)
                throw new InvalidOperationException("Pilha Vazia");
            int result = pilha.Last();
            pilha = pilha.SkipLast(1).ToArray();
            topo--;
            return result;
        }

        public int MaxPilha()
        {
            return pilha.Length;

        }

        public void Print()
        {
            var text = "";
            for (int i = 0; i < pilha.Length; i++)
            {
                if (i == 0)
                    text = pilha[i].ToString();
                else
                    text = $"{text}, {pilha[i]}";
            }
            Console.WriteLine(text);
        }
    }
}
