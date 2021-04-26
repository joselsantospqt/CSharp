using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
