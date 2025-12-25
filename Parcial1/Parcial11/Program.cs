using System;

namespace parcial11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[,] matriz = new int[n, n];
            int x = 0;

            int ms = n / 2 - 1;
            int mi = n / 2;

            for (int i = 0; i < n; i++) // Filas
            {
                for (int j = 0; j < n; j++) // Columnas
                {
                    if (i == ms)
                    {
                        if (j == 0)
                        {
                            x = 1;
                        }
                        else
                        {
                            x += 2;
                        }
                        matriz[i, j] = x;
                    }
                    else if (i == mi)
                    {
                        if (j == 0)
                        {
                            x = 2;
                        }
                        else
                        {
                            x += 2;
                        }
                        matriz[i, j] = x;
                    }
                    else
                    {
                        matriz[i, j] = 0;
                    }
                }
            }

            Console.WriteLine("\nLa matriz final es:\n");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}