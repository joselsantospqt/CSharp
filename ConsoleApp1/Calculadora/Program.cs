using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            int a;
            int b;
            var result = "";
            var valida = "";
            var opera = "";

            try
            {
                while (loop)
                {
                    Console.WriteLine("Digite a operação");
                    Console.WriteLine("adição (+), subtração (-), multiplicação (*) e divisão (/)");
                    opera = Console.ReadLine();
                    switch (opera)
                    {
                        case "+":
                            Console.WriteLine("Digite o primeiro número");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o segundo número");
                            b = Convert.ToInt32(Console.ReadLine());
                            result = Convert.ToString(a + b);
                            Console.WriteLine($"Resultado: {a} {opera} {b} = {result}");
                            break;
                        case "-":
                            Console.WriteLine("Digite o primeiro número");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o segundo número");
                            b = Convert.ToInt32(Console.ReadLine());
                            result = Convert.ToString(a - b);
                            Console.WriteLine($"Resultado: {a} {opera} {b} = {result}");

                            break;
                        case "*":
                            Console.WriteLine("Digite o primeiro número");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o segundo número");
                            b = Convert.ToInt32(Console.ReadLine());
                            result = Convert.ToString(a - b);
                            Console.WriteLine($"Resultado: {a} {opera} {b} = {result}");
                            break;
                        case "/":
                            Console.WriteLine("Digite o primeiro número");
                            a = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o segundo número");
                            b = Convert.ToInt32(Console.ReadLine());
                            result = Convert.ToString(a - b);
                            Console.WriteLine($"Resultado: {a} {opera} {b} = {result}");
                            break;
                        default:
                            Console.WriteLine("Operação Invalida");
                            break;
                    }
                    result = "";
                    Console.WriteLine("RESETAR(R)/ENCERRAR(E)");
                    valida = Console.ReadLine().ToString().ToUpper();
                    switch (valida)
                    {
                        case "R":
                            loop = true;
                            break;
                        case "E":
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("OPERAÇÃO ENCERRADA! {COMMAND ERROR}");
                            loop = false;
                            break;
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("---------{COMMAND ERROR}---------");
                Console.WriteLine(e.Message);
                Console.WriteLine("---------{COMMAND ERROR}---------");
            }

        }
    }
}
