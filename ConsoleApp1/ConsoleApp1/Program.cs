using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Escreva o número do exercicio:");
            var escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 0:
                    VerificaIdade.ExecutaVerificaIdade();
                    break;
                case 1:
                    VerificaPositivoNegativo.ExecutaVerificaNumero();
                    break;
                case 2:
                    TesteDeImpressao.ExecutaTesteDeImpressao();
                    break;
                case 3:
                    TabelaMultiplicacao.ExecutaTabelaMultiplicacao();
                    break;
                case 4:
                    Fatorial.ExecutaFatorial();
                    break;
                case 5:
                    DesenhaPiramede.ImprimePiramede();
                    break;
                case 6:
                    break;
                case 7:

                    break;
                case 8:

                    break;

                default:
                    var quantidade = args.Length;
                    int somatorio = 0;
                    int i = 0;

                    while (i < quantidade)
                    {
                        if (i >= quantidade)
                        { break; }
                        somatorio = somatorio + Convert.ToInt32(args[i]);

                        i++;
                    }

                    Console.WriteLine(somatorio);

                    int[] numeros = new int[] { 10, 25, 41, 57, 60, 5, 2, 3, 7 / 8, 99 };



                    Console.ReadKey();
                    break;


            }





        }
    }
}
