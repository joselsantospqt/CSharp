using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFilaXPilha
{
    public class Fila
    {
        protected int[] fila = new int[10];
        protected int FF = -1;

        public void Push(int obj)
        {
            if (fila != null && fila.Length != 0 && FF == fila.Length - 1)
                throw new InvalidOperationException("Pilha Cheia");
            if (fila.Length == 0)
                fila = new int[10];
            FF++;
            fila[FF] = obj;
        }

        public int Pop()
        {
            if (fila.Length == 0 || FF == -1)
                throw new ArgumentNullException("Pilha Vazia");
            int result = fila.First();
            fila = fila.Skip(1).ToArray();
            FF--;
            return result;
        }

        public int MaxFila()
        {
            return fila.Length;
        }

        public void Print()
        {
            var text = "";
            for (int i = 0; i < fila.Length; i++)
            {
                if (i == 0)
                    text = fila[i].ToString();
                else
                    text = $"{text}, {fila[i]}";
            }
            Console.WriteLine(text);
        }
    }
}
