using System;
using System.Timers;

/*=============================================================================
 * PURPOSE: Creates a random number and request the user a number from keyboard.
 * Catch any exception. Allso, throws custom exception when the typed number
 * is smaller or bigger.
 * ==========================================================================*/
namespace Laboratorio02_ejercicio01
{
    public class FailedNumberException : Exception
    {
        private string messageM;
        public FailedNumberException(string message) : base(message)
        {
            messageM = message;
        }

        public string getMessage()
        {
            return messageM;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int MAX_NUMBER = 100;

            // Create a random number generator.
            var generator = new Random();

            // Create a random integer from 0 to 20.
            int targetNumber = generator.Next(MAX_NUMBER + 1);
            bool found = false;

            Console.WriteLine($"Tienes que acertar un numero entre 0 y {MAX_NUMBER}.");
            // Up to 10 tries.
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine($"Te quedan {10 - i} intentos. Introduce un numero: ");
                    string typedString = Console.ReadLine();
                    int typedNumber = int.Parse(typedString);

                    if (typedNumber == targetNumber)
                    {
                        found = true;
                        break;
                    }
                    else if (typedNumber < targetNumber)
                    {
                        throw new FailedNumberException("El numero introducido es menor.");
                    }
                    else
                    {
                        throw new FailedNumberException("El numero introducido es mayor.");
                    }
                }
                catch (FormatException ex)
                {
                    Console.Write("El dato introducido no es un numero entero." + "\n" + ex.Message + "\n");
                    // Does not count this turn.
                    i--;
                }
                catch (OverflowException ex)
                {
                    Console.Write("El numero introducido se sale de rango." + "\n" + ex.Message + "\n");
                    // Does not count this turn.
                    i--;
                }
                catch (FailedNumberException ex)
                {
                    Console.Write("\n" + ex.getMessage() + "\n");
                }
            }
            
            // Shows result.
            if (found)
            {
                Console.WriteLine($"Felicidades!! El numero secreto era {targetNumber}.");
            }
            else
            {
                Console.WriteLine($"Que pena!! No acertaste el numero. El numero secreto era {targetNumber}.");
            }
        }
    }
}

