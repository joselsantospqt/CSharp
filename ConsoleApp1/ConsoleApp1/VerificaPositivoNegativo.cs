using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class VerificaPositivoNegativo
    {
        public static void ExecutaVerificaNumero()
        {

            Console.WriteLine("Escreva um número");
            var numero = Convert.ToInt32(Console.ReadLine());
            if (numero > 0)
                Console.WriteLine("Positivo");
            else
                Console.WriteLine("negativo");
        }
    }
}
