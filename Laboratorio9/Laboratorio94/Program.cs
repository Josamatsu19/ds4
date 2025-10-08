using System;
using System.Linq;

namespace Laboratorio94
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- EJERCICIO 5: ARREGLO DE NÚMEROS NO REPETIDOS ---");

            Aleatorios generador = new Aleatorios();

            int limiteInferior = 1;
            int limiteSuperior = 25;
            int cantidadElementos = 15;

            Console.WriteLine($"\nParámetros: Rango [{limiteInferior}-{limiteSuperior}], Cantidad: {cantidadElementos}");

            try
            {
                int[] arregloUnico = generador.GenerarArregloNoRepetido(limiteInferior, limiteSuperior, cantidadElementos);

                Console.WriteLine("\nArreglo generado (sin números repetidos):");
                Console.WriteLine("[" + string.Join(", ", arregloUnico) + "]");
                Console.WriteLine($"Total de elementos: {arregloUnico.Length}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nSe ha producido un error: {ex.Message}");
            }
        }
    }
}