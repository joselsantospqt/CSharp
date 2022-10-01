using System;
using System.Linq;

namespace RecursividadeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayList = new int[10000];
            int Contador = 0;
            int numero = 0;
            int n;

            PreencheArray(arrayList);

            Console.WriteLine("Insira o número a ser pesquisado:");
            var vBuscar = Console.ReadLine();
            var result = Int32.TryParse(vBuscar, out n);
            if (result)
            {
                numero = Convert.ToInt32(vBuscar);
            }
            else
                throw new Exception("Não é um número valido");

            //Verificando de forma recursiva
            for (var i = 0; i < arrayList.Count(); i++)
            {
                if (arrayList[i] == numero)
                    Contador++;
            }
            Console.WriteLine("Resultado Recursiva:");
            Console.WriteLine(Contador);

            //Verificando de forma iterativa
            var quantidadeRepetido = arrayList.Where(x => x == numero).ToList().Count();
            Console.WriteLine("Resultado Iterativa:");
            Console.WriteLine(quantidadeRepetido);
        }

        private static void PreencheArray(int[] arrayList)
        {
            for (var i = 0; i < arrayList.Count(); i++)
            {
                arrayList[i] = RandomNumber();
            }
        }

        public static int RandomNumber()
        {
            Random generator = new Random();
            return generator.Next(0, 99);
        }
    }
}
