using System;

namespace Laboratorio83
{
    // Propiedades de lectura y escritura
    public class Empleado
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }

    // Propiedades con validación
    public class CuentaBancaria
    {
        private decimal saldo;
        public decimal Saldo
        {
            get { return saldo; }
            set
            {
                if (value >= 0)
                    saldo = value;
                else
                    throw new ArgumentException("El saldo no puede ser negativo.");
            }
        }
    }

    // Propiedades de solo lectura
    public class Cobertura
    {
        private double radio;

        public Cobertura(double radio)
        {
            this.radio = radio;
        }

        public double Radio
        {
            get { return radio; }
            // Note: El 'set' está ausente, haciéndola de solo lectura fuera del constructor
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Prueba de Empleado (Lectura/Escritura)
            Empleado empleado = new Empleado();
            empleado.Nombre = "John Doe";
            Console.WriteLine($"Nombre del empleado: {empleado.Nombre}");

            // Prueba de CuentaBancaria (Con Validación)
            CuentaBancaria cta = new CuentaBancaria();
            cta.Saldo = 100;
            Console.WriteLine($"El saldo del empleado: {cta.Saldo}");
            // Para probar la excepción: cta.Saldo = -50;

            // Prueba de Cobertura (Solo Lectura)
            Cobertura c = new Cobertura(5);
            Console.WriteLine($"Con una cobertura de: {c.Radio}");
        }
    }
}