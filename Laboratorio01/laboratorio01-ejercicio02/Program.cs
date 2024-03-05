using System;

namespace lab01_ej2_project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int a, b;

            Console.WriteLine("Entre el primer numero: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre el segundo numero: ");
            b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine("El primer numero es mayor que el segundo");
            }
            else if (b > a)
            {
                Console.WriteLine("El segundo numero es mayor que el primero");
            }
            else
            {
                Console.WriteLine("Los numeros son iguales");
            }
        }
    }
}
