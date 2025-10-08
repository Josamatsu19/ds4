using System;

namespace Laboratorio92
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- EJERCICIO 3: CLASIFICACIÓN DE TRIÁNGULO ---");

            Func<string, double> pedirLado = (nombre) =>
            {
                double lado;
                do
                {
                    Console.Write($"Ingrese el valor para el lado {nombre} (positivo): ");
                } while (!double.TryParse(Console.ReadLine(), out lado) || lado <= 0);
                return lado;
            };

            double a = pedirLado("A");
            double b = pedirLado("B");
            double c = pedirLado("C");

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                Console.WriteLine("\nCon estos lados NO se puede formar un triángulo (no cumple la desigualdad triangular).");
            }
            else
            {
                string tipo = "";
                if (a == b && b == c)
                {
                    tipo = "EQUILÁTERO (los 3 lados son iguales).";
                }
                else if (a == b || a == c || b == c)
                {
                    tipo = "ISÓSCELES (al menos 2 lados son iguales).";
                }
                else
                {
                    tipo = "ESCALENO (los 3 lados son diferentes).";
                }
                Console.WriteLine($"\nLos lados ingresados forman un triángulo de tipo: {tipo}");
            }
        }
    }
}
