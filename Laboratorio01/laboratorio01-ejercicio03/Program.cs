using System;

namespace lab01_ej3_proyect
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca dia de la semana!");
            string day = Console.ReadLine();

            switch (day)
            {
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                case "viernes":
                    Console.WriteLine("Es dia laborable.");
                    break;
                case "sabado":
                case "domingo":
                    Console.WriteLine("Es fin de semana.");
                    break;
                default:
                    Console.WriteLine("Error. Ese valor no es ningun dia de la semana.");
                    break;
            }

        }
    }
}
