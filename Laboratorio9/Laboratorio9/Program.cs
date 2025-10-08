using System;

namespace Laboratorio9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal precio = 0;
            string formaPago = "";
            string numeroCuenta = "";

            do
            {
                Console.Write("Ingrese el precio del producto (valor positivo): ");
            } while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0);

            do
            {
                Console.Write("Ingrese la forma de pago (efectivo/tarjeta): ");
                formaPago = Console.ReadLine()?.Trim().ToLower() ?? "";
            } while (formaPago != "efectivo" && formaPago != "tarjeta");

            if (formaPago == "tarjeta")
            {
                bool cuentaValida = false;
                do
                {
                    Console.Write("Ingrese el número de cuenta (16 dígitos): ");
                    numeroCuenta = Console.ReadLine()?.Trim() ?? "";

                    if (numeroCuenta.Length == 16 && long.TryParse(numeroCuenta, out _))
                    {
                        cuentaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: El número de cuenta debe tener exactamente 16 dígitos numéricos.");
                    }
                } while (!cuentaValida);
            }

            Console.WriteLine("\n--- RESUMEN DE PAGO ---");
            Console.WriteLine($"Precio: {precio:C}");
            Console.WriteLine($"Forma de pago: {formaPago.ToUpper()}");
            if (formaPago == "tarjeta")
            {
                Console.WriteLine($"Cuenta (últimos 4 dígitos): **** **** **** {numeroCuenta.Substring(12)}");
            }
        }
    }
}
