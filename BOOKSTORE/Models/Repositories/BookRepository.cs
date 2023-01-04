using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKSTORE.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
             {
                new Book
                {
                    Id=1 ,
                    Title="C# Programming" ,
                    Description="No Description ",
                    imgeUrl="b1.png",
                    Author=new Author{Id=2}
                },
                  new Book
                {
                    Id=2 ,
                    Title="JAVA Programming" ,
                    Description=" Nothing ",
                    imgeUrl="b2.jpg",
                    Author=new Author()
                },
                    new Book
                {
                    Id=3 ,
                    Title="C# Programming" ,
                    Description="No Data ",
                    imgeUrl="b3.jpg",
                    Author=new Author()
                },

              };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book =books.SingleOrDefault(b => b.Id==id);
            return book;

        }

        public IList<Book> List()
        {

            return books;
        }

        public List<Book> search(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void Update(int id,Book newbook)
        {
            var book = Find(id);
            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Author = newbook.Author;
            book.imgeUrl = newbook.imgeUrl;
        }
    }
}
