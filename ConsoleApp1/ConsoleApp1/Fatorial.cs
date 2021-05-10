using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Fatorial
    {
        public static void ExecutaFatorial()
        {
            double n, numero, resultado;
            Console.WriteLine("Informe o número");
            numero = double.Parse(Console.ReadLine());
            n = numero;
            resultado = 1;
            while (n != 1)
            {
                resultado = resultado * n;
                n -= 1;
            }

            Console.WriteLine($"\nFatorial de {numero} é {resultado} ");
            Console.ReadLine();
        }
    }
}
