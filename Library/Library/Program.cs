using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            count = UserInterface.GetAll().Count;

            bool IsContinue = true;

            int choise = 0;            
            while (IsContinue)
            {
                Console.WriteLine("1) Добавить книгу");
                Console.WriteLine("2) Вывод всех книг");
                Console.WriteLine("3) Поиск по id");
                Console.WriteLine("4) Поиск по названию и автору");
                Console.WriteLine("5) Выход");

                int.TryParse(Console.ReadLine(),out choise);

                switch (choise)
                {
                    case 1:
                        UserInterface.AddBook(CreateBook(count));
                        break;

                    case 2:
                        foreach (var i in UserInterface.GetAll())
                        {
                            Console.WriteLine(i.Id);
                            Console.WriteLine(i.Name);
                            Console.WriteLine(i.AuthorName);
                            Console.WriteLine(i.Pages + "\n");
                        }
                        break;

                    case 3:
                        int id;

                        Console.WriteLine("Введите id");
                        int.TryParse(Console.ReadLine(), out id);

                        Console.WriteLine(UserInterface.GetById(id).Id);
                        Console.WriteLine(UserInterface.GetById(id).Name);
                        Console.WriteLine(UserInterface.GetById(id).AuthorName);
                        Console.WriteLine(UserInterface.GetById(id).Pages);
                        break;

                    case 4:
                        string name;
                        string authorName;

                        Console.WriteLine("Введите название книги");
                        name = Console.ReadLine();

                        Console.WriteLine("Введите автора");
                        authorName = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine(UserInterface.GetByNameAndAuthorName(name, authorName).Id);
                        Console.WriteLine(UserInterface.GetByNameAndAuthorName(name, authorName).Name);
                        Console.WriteLine(UserInterface.GetByNameAndAuthorName(name, authorName).AuthorName);
                        Console.WriteLine(UserInterface.GetByNameAndAuthorName(name, authorName).Pages + "\n");                        

                        break;

                    case 5:
                        IsContinue = false;
                        break;
                }

            }
        } 

        public static Book CreateBook(int count)
        {           
            int pages;
            string bookName;
            string authorName;

            Console.WriteLine("Введите название книги");
            bookName = Console.ReadLine();

            Console.WriteLine("Введите имя автор");
            authorName = Console.ReadLine();

            Console.WriteLine("Введите кол-во страниц");
            int.TryParse(Console.ReadLine(), out pages);

            return new Book
            {
                Id = count,
                AuthorName = authorName,
                Name = bookName,
                Pages = pages
            };
        }
    }
}
