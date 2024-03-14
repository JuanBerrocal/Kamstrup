using System;

/*=============================================================================
 * PURPOSE: Cretaes an array of books, and given the title searchs the book
 * in the array an returns whether the book is read or not.
 * Also throws a custom exception when the given title is not found.
 * ==========================================================================*/

namespace Ejercicio01
{

    public class Book
    {
        public string Title { get; set; }
        public bool IsRead { get; set; }

    }
    public class BookNotFoundException : Exception {
        private string message;
        public BookNotFoundException(string messageP)
        {
            message = messageP;
        }
        public string getMessage()
        {
            return message;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Book[] books = new Book[]  {
                new Book {
                    Title = "Don Quijote de la Mancha",
                    IsRead = true
                },
                new Book {
                    Title = "Fundacion",
                    IsRead = false
                },
                new Book {
                    Title = "El señor de los anillos",
                    IsRead = false
                },
                new Book {
                    Title = "Cien años de soledad",
                    IsRead = true
                },
                new Book {
                    Title = "El barón rampante",
                    IsRead = false
                },
            };

            bool IsBookRead(Book[] booksP, string titleP)
            {
                for (int i = 0; i < booksP.Length; i++)
                {
                    if (booksP[i].Title == titleP)
                    {
                        return booksP[i].IsRead;
                    }
                }
                throw new BookNotFoundException($"El libro {titleP} no esta en la lista");
            }

            Console.WriteLine("Recorre una serie de libros e indica si se han leido o no.");

            string[] targets = {"Fundacion", "La historia interminable", "Cien años de soledad", "El barón rampante"};

            foreach (var target in targets)
            {
                try
                {
                    bool read = IsBookRead(books, target);

                    Console.WriteLine($"El libro {target} {(read ? ("si") : ("no"))} se ha leido.");
                }
                catch (BookNotFoundException ex) {
                    Console.WriteLine(ex.getMessage());
                }
                
            }
            

        }
    }
}
