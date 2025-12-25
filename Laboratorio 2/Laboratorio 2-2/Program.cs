using System;
namespace Laboratorio21
{

    public class program
    {
        public static void Main()
        {
            //Asignando valor a variable estatica 
            MyClass.Valor = 1;
            Console.WriteLine(MyClass.Valor);
        }
    }
    public class MyClass
    {
        //Declarando varible estatica
        public static int Valor;
    }
}