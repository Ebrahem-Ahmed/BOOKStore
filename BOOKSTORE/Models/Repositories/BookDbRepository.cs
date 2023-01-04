using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKSTORE.Models.Repositories
{
    public class BookDbRepository : IBookstoreRepository<Book>
    {
        BookstoreDbContext db;
        public BookDbRepository(BookstoreDbContext _db)
        {
            db = _db;
        }
        public void Add(Book entity)
        {
          //  entity.Id = books.Max(b => b.Id) + 1;
          db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();

        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
            return book;

        }

        public IList<Book> List()
        {

            return db.Books.Include(a=>a.Author).ToList();

        }

        public void Update(int id, Book newbook)
        {
            db.Update(newbook);
            db.SaveChanges();
        }
        public List<Book> search (string term)
        {
            var result = db.Books.Include(a => a.Author)
                .Where(b => b.Title.Contains(term)
                   || b.Description.Contains(term) 
                   || b.Author.FullName.Contains(term)).ToList();
            return result;
        }
    }
}

