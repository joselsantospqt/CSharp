using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DesenhaPiramede
    {

        public static void ImprimePiramede()
        {
            int space = 3;
            int number = 1;

            for (int i = 1;i <= 10; i++) {

                for (int s = space; s >= 1; s--)
                {
                    Console.WriteLine(" ");
                }

                for (int l = 1; l <= i; l++) {
                    Console.Write($"{number}");
                    number = number + 1;

                }

                Console.WriteLine();
                space = space - 1;

            }
        }
    }
}
