using System;

//*****************************************************************************
// PURPOSE: Drawing a pyramid. The pyramid is made of a character c and
// has n levels. We must input c and n by keyboard.
//*****************************************************************************

namespace laboratorio01_ejercicio06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c;
            int n;
            
            Console.WriteLine("Input a character: ");
            c = char.Parse(Console.ReadLine());
            Console.WriteLine("Input number of levels: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                string level = "";    

                for (int j = 0; j < i; j++)
                {
                    char brick = ((j > 0) && (j < i - 1) && (i != n)) ? ' ' : c;
                    level = level + brick;
                }
                Console.WriteLine(level);
            }
        }
    }
}
