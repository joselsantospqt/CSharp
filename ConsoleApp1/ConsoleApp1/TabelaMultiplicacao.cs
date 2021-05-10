using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TabelaMultiplicacao
    {

        public static void ExecutaTabelaMultiplicacao()
        {
            Console.WriteLine("Digite um número para começar");
            var numero = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i <= 10; i++)
            {
                int resultado = numero * i;
                Console.WriteLine($"{numero}x{i} = {resultado}");
            }
        }
    }
}
