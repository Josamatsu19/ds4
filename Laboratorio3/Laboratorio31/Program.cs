
using System;

namespace Laboratorio31
{
    class CalculosMatematicos
    {
        public Double Calcular(double numA, double numB)
        {
            return (numA + numB) * (numA - numB);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Double numA, numB, resultado;

            Console.WriteLine("Porfavor, ingrese el primer numero");
            numA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Porfavor, ingrese el segundo numero");
            numB = Convert.ToDouble(Console.ReadLine());

            CalculosMatematicos calculosMatematicos = new CalculosMatematicos();

            resultado = calculosMatematicos.Calcular(numA, numB);

            Console.WriteLine("El resultado de la operación ({0} + {1}) * ({0} - {1}) es: {2}", numA, numB, resultado);
        }

    }
}

 