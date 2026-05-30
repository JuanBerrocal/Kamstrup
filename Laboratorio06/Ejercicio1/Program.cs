// See https://aka.ms/new-console-template for more information


using Ejercicio1;

string email = "";
EmailValidator validator = new EmailValidator();

Console.WriteLine("TESTEADOR DE EMAILS");

while (email != "quit")
{
    Console.WriteLine("Introduce un correo electronico (o quit para salir): ");
    email = Console.ReadLine() ?? "";
    
    if (email != "quit")
    {
        if   (validator.Check(email))
        {
            Console.WriteLine("Ese email es correcto.");
        }
        else
        {
            Console.WriteLine("Ese email tiene errores.");
        }
    }
      
}


