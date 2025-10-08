using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio93
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
    }
}
