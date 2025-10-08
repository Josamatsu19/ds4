using System;

namespace Laboratorio84
{
    // Primera parte de la clase Coordenadas (contiene campos y constructor)
    public partial class Coordenadas
    {
        private int x;
        private int y;

        public Coordenadas(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // Segunda parte de la clase Coordenadas (contiene el método)
    public partial class Coordenadas
    {
        public void VerCoordenadas()
        {
            Console.WriteLine("Coordenadas: {0}, {1}", x, y);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // El objeto usa miembros definidos en ambas partes parciales
            Coordenadas misCoords = new Coordenadas(10, 15);
            misCoords.VerCoordenadas();
        }
    }
}