using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS4_Proyecto1_WinFormsApp
{
    public static class CalculadoraLogic
    {
        public static double Sumar(double num1, double num2) => num1 + num2;
        public static double Restar(double num1, double num2) => num1 - num2;
        public static double Multiplicar(double num1, double num2) => num1 * num2;

        public static double Dividir(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("No se puede dividir por cero.");
            return num1 / num2;
        }

        public static double ElevarAlCuadrado(double num) => num * num;

        public static double RaizCuadrada(double num)
        {
            if (num < 0)
                throw new ArgumentException("No se puede obtener la raíz cuadrada de un número negativo.");
            return Math.Sqrt(num);
        }

        public static double Potencia(double baseNum, double exponente) => Math.Pow(baseNum, exponente);
        public static double Modulo(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("No se puede calcular el módulo con un divisor de cero.");
            return num1 % num2;
        }
    }
}
