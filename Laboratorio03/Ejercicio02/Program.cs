using System;
using System.Diagnostics;

namespace Ejercicio02
{
    public class SlotMachine
    {
        public bool Roulette1 { get; set; }
        public bool Roulette2 { get; set; }
        public bool Roulette3 { get; set; }

        public int Coins { get; set; }

        public SlotMachine() {
            Roulette1 = false;
            Roulette2 = false;
            Roulette3 = false;
            Coins = 0;
        }

        public void play() {
            var generator = new Random();

            Coins++;
            Roulette1 = (generator.Next(2) == 0);
            Roulette2 = (generator.Next(2) == 0);
            Roulette3 = (generator.Next(2) == 0);
            Console.WriteLine(
                $"{(Roulette1 ? "$" : "o")} " +
                $"- {(Roulette2 ? "$" : "o")} " +
                $"- {(Roulette3 ? "$" : "o")}");

            if (Roulette1 && Roulette2 && Roulette3)
            {
                Console.WriteLine($"Congratulations!! You won {Coins} coins.");
                Coins = 0;
            }
            else
            {
                Console.WriteLine("Good luck next time!!");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            SlotMachine machine = new SlotMachine();

            Console.WriteLine("Slot Machine Game.");
            Console.WriteLine("Want to play? (y/n)");
            finished = (Console.ReadLine() != "y");

            while (!finished)
            {
                machine.play();
                Console.WriteLine("Another round? (y/n)");
                finished = (Console.ReadLine() != "y");
            }
            Console.WriteLine("Thank you. See you next time.");
        }
    }
}
