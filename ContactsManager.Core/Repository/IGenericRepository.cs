using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ContactsManager.Core
{
  public interface IGenericRepository<TEntity> where TEntity : class
  {

    IEnumerable<TEntity> Get();
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
    IEnumerable<TEntity> Get(string includeProperties);
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties);
    IEnumerable<TEntity> Get(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties);
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties);
    TEntity GetById(object id);
    void Insert(TEntity entityToInsert);
    void Delete(object id);
    void Delete(TEntity entityToDelete);
    void Update(TEntity entityToUpdate);
    IEnumerable<TEntity> GetAllPaged(int page, int pageSize);
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> FindPaged(int page, int pageSize, Expression<Func<TEntity, bool>> predicate);
    int Count();
  }
}
