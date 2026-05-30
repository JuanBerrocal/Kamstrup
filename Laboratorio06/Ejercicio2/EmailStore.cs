using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{

    public interface IEmailStore
    {
        public void Add(string email);
        public bool IsStored(string email);
        public void Show();

    }
     public class EmailStore : IEmailStore
    {
        List<string> _emailList = new List<string>();

        public void Add(string email)
        {
            _emailList.Add(email);
        }

        public bool IsStored(string email)
        {
            return _emailList.Contains(email);
        }

        public void Show()
        {
            _emailList.ForEach(Console.WriteLine);
        }
    }
}
