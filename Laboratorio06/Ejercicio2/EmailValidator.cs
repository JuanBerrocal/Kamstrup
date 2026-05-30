using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class DuplicatedEmailException : Exception {
        private string _message;
        public DuplicatedEmailException(string message)
        {
            _message = message;
        }
        public string getMessage()
        {
            return _message;
        }
    }
    public class EmailValidator
    {

        private IEmailStore _store;

        public const string EMAIL_OK = "Esta direccion de correo electronico es correcta";

        public EmailValidator(IEmailStore store)
        {
            _store = store ?? new EmailStore(); 
        }

        public bool Check(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) { return false; }

            if (!email.Contains("@")) { return false; }

            var parts = email.Split('@');

            if (parts.Length != 2) { return false; }

            //if (string.IsNullOrWhiteSpace(parts[0])) { return false; }

            if (!parts[1].Contains(".")) { return false; }

            if (email.StartsWith("@") || email.EndsWith("@")) { return false; }

            if (email.StartsWith(".") || email.EndsWith(".")) { return false; }

            return true;
        }
                
        public void Show()
        {
            _store.Show();
        }

        public void Add(string email)
        {
            if (!(_store.IsStored(email)))
            {
                _store.Add(email);
            }
            else
            {
                throw new DuplicatedEmailException("Ese email ya existe");
            }
        }
    }
}
