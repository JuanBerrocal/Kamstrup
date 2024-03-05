using System;

namespace lab01_ej01_project
{
    internal class Program
    {
        public struct Person
        {
            public string name;
            public int age;
            public string city;

            public Person(string n, int a, string c)
            {
                name = n;
                age = a;
                city = c;
            }
        }
        static void Main(string[] args)
        {
            Person person = new Person("", 0, "");

            Console.WriteLine("Cual es tu nombre: ");
            person.name = Console.ReadLine();
            Console.WriteLine("Cual es tu edad: ");
            person.age = int.Parse(Console.ReadLine());
            Console.WriteLine("Donde vives: ");
            person.city = Console.ReadLine();

            Console.WriteLine($"Hola, tu nombre es {person.name} y tienes {person.age} años. Bienvenido a {person.city}.");
        }
    }
}
