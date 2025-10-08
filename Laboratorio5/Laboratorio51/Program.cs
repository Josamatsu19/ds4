using System;

namespace Laboratorio51
{
    class Program
    {
        class Matriz
        {
            private int[,] mat;

            public void Ingresar()
            {
                mat = new int[3, 4]; // Inicializa la matriz de 3 filas y 4 columnas
                for (int f = 0; f < 3; f++) // Bucle para las filas (f: 0, 1, 2)
                {
                    for (int c = 0; c < 4; c++) // Bucle para las columnas (c: 0, 1, 2, 3)
                    {
                        // Pide ingresar un valor, mostrando la posición (sumando 1 a f y c para un índice amigable)
                        Console.Write("Ingrese posicion [" + (f + 1) + "," + (c + 1) + "]: ");
                        string linea;
                        linea = Console.ReadLine();
                        mat[f, c] = int.Parse(linea); // Asigna el valor ingresado a la posición [f, c]
                    }
                }
            }
            public void Imprimir()
            {
                for (int f = 0; f < 3; f++) // Bucle para las filas (f: 0, 1, 2)
                {
                    for (int c = 0; c < 4; c++) // Bucle para las columnas (c: 0, 1, 2, 3)
                    {
                        // Muestra el elemento en [f, c] seguido de un espacio
                        Console.Write(mat[f, c] + " ");
                    }
                    Console.WriteLine(); // Salto de línea después de imprimir toda una fila
                }
                Console.ReadKey(); // Espera una pulsación de tecla para finalizar
            }
        }

        static void Main(string[] args)
        {
            Matriz ma = new Matriz(); // Crea una instancia de la clase (asumiendo que se llama Matriz)
            ma.Ingresar(); // Llama al método para pedir al usuario que ingrese los datos
            ma.Imprimir(); // Llama al método para mostrar la matriz completa
        }
    }
}