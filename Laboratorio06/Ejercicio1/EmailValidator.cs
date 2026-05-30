using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class EmailValidator
    {

        public const string EMAIL_OK = "Esta direccion de correo electronico es correcta";

        public bool Check(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) { return false; }

            if (!email.Contains("@")) { return false; }

            var parts = email.Split('@');

            if (parts.Length != 2) { return false; }

            //if (string.IsNullOrWhiteSpace(parts[0])) { return false; }

            if (!parts[1].Contains(".")) { return false; }

            if (email.StartsWith("@") || email.EndsWith("@")) { return false;}

            if (email.StartsWith(".") || email.EndsWith(".")) { return false; }

            return true;
        }
    }
}
