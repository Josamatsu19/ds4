using System;

namespace Laboratorio93
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Instanciar la clase Aleatorios
            Aleatorios generador = new Aleatorios();

            int limiteInferior = 10;
            int limiteSuperior = 100;
            int elementosArreglo = 15;

            Console.WriteLine($"\nParámetros de prueba: Rango [{limiteInferior}-{limiteSuperior}]");

            int numeroAleatorio = generador.GenerarNumero(limiteInferior, limiteSuperior);
            Console.WriteLine($"\n1. Número generado entre {limiteInferior} y {limiteSuperior}: {numeroAleatorio}");

            int[] arregloResultante = generador.GenerarArreglo(limiteInferior, limiteSuperior, elementosArreglo);
            Console.WriteLine($"\n2. Arreglo de {elementosArreglo} números generados:");
            Console.WriteLine("[" + string.Join(", ", arregloResultante) + "]");
        }
    }
}