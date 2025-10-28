using System;

namespace Parcial12
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 1;
            int resu = 0;

            Console.Write("Introduce número de términos: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Entrada inválida. Debe ser un número mayor que 0.");
                return;
            }
            for (int i = 0; i <= n; i++)
            {
                resu = a + b;
                a = b;
                b = resu;
            }

            Console.WriteLine();
            Console.WriteLine("Resultado: " + a);
        }
    }
}