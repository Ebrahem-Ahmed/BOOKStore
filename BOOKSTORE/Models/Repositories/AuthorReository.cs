using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKSTORE.Models.Repositories
{
    public class AuthorReository : IBookstoreRepository<Author>
    {
        List<Author> authors;
        public AuthorReository()
        {
            authors = new List<Author>()
            {
                new Author{Id=1,FullName="Ebrahem"},
                new Author{Id=2,FullName="mayo"},
                new Author{Id=3,FullName="mona"},


            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;

            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a=>a.Id==id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public List<Author> search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();

        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
        }
    }
}
