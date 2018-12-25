using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class UserInterface
    {
        public static void AddBook(Book book)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Add(book);

                context.SaveChanges();
            }
        }

        public static List<Book> GetAll()
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Books.ToList();
            }            
        }

        public static Book GetById(int Id)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from i in context.Books.ToList()
                             where i.Id == Id
                             select i;

                if (result.Count() > 0)
                    return result.ElementAt(0);
                else
                    return new Book { Name = "Нет", Pages = 0, AuthorName = "Нет", Id = 404 };
            }
        }

        public static Book GetByNameAndAuthorName(string NameBook, string AuthorName)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from i in context.Books.ToList()
                             where i.Name == NameBook
                             where i.AuthorName == AuthorName
                             select i;

                if (result.Count() > 0)
                    return result.ElementAt(0);
                else
                    return new Book { Name = "Нет", Pages = 0, AuthorName = "Нет", Id = 404 };
            }
        }
    }
}
