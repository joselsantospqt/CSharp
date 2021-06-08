using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEx
{
    class TesteDeImpressao
    {
        public static void ExecutaTesteDeImpressao()
        {
            Console.WriteLine("Digite um número para começar");
            var numero = Convert.ToInt32(Console.ReadLine());
            var a = "";
            Console.WriteLine();
            for (var i = 0; numero > i; i++)
            {
                a = a + "*";
                Console.WriteLine(a);
            }
        }
    }
}
