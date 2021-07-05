using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEx
{
    class TestSinqia
    {
        public static int maxXor(int lo, int hi, int k)
        {
        //REGRAS 
        // 1 <= lo < hi <= 10^4
        // 1 <= k <= 10^4
        //www.dotnetperls.com/xor


            int retorno = 0;
            if (lo < 1 || lo >= hi)
                return 0;

            if (hi <= lo || hi > Math.Pow(10, 4))
                return 0;

            if (k < 1 || k > Math.Pow(10, 4))
                return 0;

            for (int x = lo; x <= hi; x++)
            {
                for (int y = x + 1; y <= hi; y++)
                {
                    int valor = x ^ y;
                    Console.WriteLine(x + " - " + y + " = " + valor);
                    if (valor <= k && valor > retorno)
                        retorno = valor;
                }
            }
            return retorno;
        }
    }
}
