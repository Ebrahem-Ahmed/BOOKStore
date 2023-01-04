using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKSTORE.Models.Repositories
{
    public class AuthorDbRepository : IBookstoreRepository<Author>
    {
        BookstoreDbContext db;
    public AuthorDbRepository(BookstoreDbContext _db)
    {
            db = _db;
    }
    public void Add(Author entity)
    {
            //  entity.Id = authors.Max(b => b.Id) + 1;

            db.Authors.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int id)
    {
        var author = Find(id);
        db.Authors.Remove(author);
            db.SaveChanges();

        }

        public Author Find(int id)
    {
        var author = db.Authors.SingleOrDefault(a => a.Id == id);
        return author;
    }

    public IList<Author> List()
    {
        return db.Authors.ToList();
    }

        public List<Author> search(string term)
        {
            return db.Authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newAuthor)
    {
            // var author = Find(id);
            // author.FullName = newAuthor.FullName;

            db.Update(newAuthor);
            db.SaveChanges();
    }
}
}