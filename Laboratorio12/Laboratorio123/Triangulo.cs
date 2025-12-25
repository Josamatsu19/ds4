using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio123
{
    public class Triangulo
    {
        public bool EsTrianguloValido(decimal a, decimal b, decimal c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        public decimal CalcularSemiperimetro(decimal a, decimal b, decimal c)
        {
            return (a + b + c) / 2m;
        }

        public decimal CalcularArea(decimal a, decimal b, decimal c)
        {
            decimal s = CalcularSemiperimetro(a, b, c);
            decimal interior = s * (s - a) * (s - b) * (s - c);

            if (interior <= 0)
                return 0m;

            return (decimal)Math.Sqrt((double)interior);
        }
    }
}
