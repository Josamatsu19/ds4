using Syatem;

namespace Laboratorio82
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Llama a Suma(double, double)
            Console.WriteLine(Suma(1.0, 2.2));

            // También se puede probar con los otros tipos:
            // Console.WriteLine(Suma(1, 2));      // Llama a Suma(int, int)
            // Console.WriteLine(Suma(1L, 2L));    // Llama a Suma(long, long)
        }

        static int Suma(int x, int y)
        {
            return x + y;
        }

        static double Suma(double x, double y)
        {
            return x + y;
        }

        static long Suma(long x, long y)
        {
            return x + y;
        }
    }
}