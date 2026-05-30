// See https://aka.ms/new-console-template for more information


using Ejercicio2;

string email = "";
EmailValidator validator = new EmailValidator(new EmailStore());

Console.WriteLine("TESTEADOR DE EMAILS");

while (email != "quit")
{
    Console.WriteLine("Introduce un correo electronico (show para mostrar los emails introducidos, quit para salir): ");
    email = Console.ReadLine() ?? "";

    if (email == "show")
    {
        
        validator.Show();
    }
    else if (email != "quit")
    { 
        if (validator.Check(email))
        {
            try 
            { 
                validator.Add(email);
                Console.WriteLine("Ese email es correcto.");
            }
            catch (DuplicatedEmailException ex) 
            { 
                Console.WriteLine(ex.getMessage()); 
            }
        }
        else
        {
            Console.WriteLine("Ese email tiene errores.");
        }
    }

}