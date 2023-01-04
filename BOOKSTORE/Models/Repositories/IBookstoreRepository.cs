using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKSTORE.Models.Repositories
{
   public interface IBookstoreRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity); // ADD reposetory
        void Update(int id,TEntity entity);
        void Delete(int id);
        List<TEntity> search(string term);
    }
}