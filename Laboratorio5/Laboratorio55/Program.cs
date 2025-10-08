using System;

namespace Laboratorio55
{
    class Program
    {
        Dictionary<string, string> paisesYCapitales = new Dictionary<string, string>
{
    {"Francia", "París"},
    {"España", "Madrid"},
    {"Italia", "Roma"}
};
        static void Main(string[] args)
        {
            foreach (KeyValuePair<string, string> par in paisesYCapitales)
            {
                Console.WriteLine("La capital de " + par.Key + " es " + par.Value + ".");
            }
        }
    }
}
