using System;

namespace ConsoleFilaXPilha
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha p = new Pilha();
            p.Push(1);
            p.Push(2);
            p.Push(3);
            p.Push(4);
            p.Push(5);
            p.Push(6);
            p.Push(7);
            p.Push(8);
            p.Push(9);
            p.Push(10);

            Fila f = new Fila();
            for (int i = p.MaxPilha(); i > 0; i--) {
                f.Push(p.Pop());
            }
            f.Print();


            for (int i = f.MaxFila(); i > 0; i--)
            {
                p.Push(f.Pop());
            }
            p.Print();


        }
    }
}
