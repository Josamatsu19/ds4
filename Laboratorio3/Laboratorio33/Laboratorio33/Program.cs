using System;

namespace Laboratorio31
{
    public class Program
    {
        static void Main(string[] args)
        {
            double ladoA;
            double ladoB;
            double perimetro;

            Console.Write("Por favor, introduce la longitud del Lado A: ");
            while (!double.TryParse(Console.ReadLine(), out ladoA) || ladoA <= 0)
            {
                Console.Write("Introduce un número positivo para el Lado A: ");
            }

            Console.Write("Por favor, introduce la longitud del Lado B: ");
            while (!double.TryParse(Console.ReadLine(), out ladoB) || ladoB <= 0)
            {
                Console.Write("Introduce un número positivo para el Lado B: ");
            }
            perimetro = 2 * (ladoA + ladoB);

            Console.WriteLine($"Lado A introducido: {ladoA}");
            Console.WriteLine($"Lado B introducido: {ladoB}");
            Console.WriteLine($"El perímetro del rectángulo es: {perimetro}");
        }
    }
}
