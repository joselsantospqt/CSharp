using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEx
{
    class VerificaIdade
    {
        public static void ExecutaVerificaIdade()
        {
            Console.WriteLine("Escreva seu nome");
            var nome = Console.ReadLine();
            Console.WriteLine("Escreva sua idade");
            var idade = Convert.ToInt32(Console.ReadLine());
            if (idade > 18)
                Console.WriteLine(nome + " é maior de 18 anos");
            else
                Console.WriteLine(nome + " é menor de 18 anos");
        }
    }
}
