using System;

namespace Laboratorio54
{
    class Program
    {
        class Estudiante
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }

        List<Estudiante> estudiantes = new List<Estudiante>
{
    new Estudiante { Nombre = "Ana", Edad = 12 },
    new Estudiante { Nombre = "Juan", Edad = 10 },
    new Estudiante { Nombre = "Sofía", Edad = 11 }
};
        static void Main(string[] args) {

foreach (Estudiante estudiante in estudiantes)
{
    Console.WriteLine("Nombre: " + estudiante.Nombre + ", Edad: " + estudiante.Edad);
}
}
}