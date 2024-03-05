using System;

/*=============================================================================
 * PURPOSE: Request a number N from user and print a list of N random numbers.
 * ==========================================================================*/
namespace lab01_ej5_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca un numero: ");
            string c = Console.ReadLine();
            var n = Convert.ToInt32(c);
            Console.WriteLine("Lista de " + n + " numeros aleatorios");

            var random = new Random();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(random.Next(0, 1000));
            }

        }
    }
}
