using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio94
{
    internal class Aleatorios
    {
        private Random _random;

        public Aleatorios()
        {
            _random = new Random();
        }

        public int GenerarNumero(int min, int max)
        { 
            return _random.Next(min, max + 1);
        }

        public int[] GenerarArreglo(int min, int max, int cantidad)
        {
            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = GenerarNumero(min, max);
            }
            return arreglo;
        }

        public int[] GenerarArregloNoRepetido(int min, int max, int cantidad)
        {
            int rango = max - min + 1;

            if (cantidad > rango)
            {
                throw new ArgumentException($"Error: No es posible generar {cantidad} números no repetidos en el rango [{min}-{max}] (solo hay {rango} posibles números).");
            }

            HashSet<int> numerosUnicos = new HashSet<int>();

            while (numerosUnicos.Count < cantidad)
            {
                int nuevoNumero = GenerarNumero(min, max);
                numerosUnicos.Add(nuevoNumero);
            }

            return numerosUnicos.ToArray();
        }
    }
}
