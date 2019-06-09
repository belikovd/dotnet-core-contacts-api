using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DotNetCore.DataAccess.Abstractions.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void DeleteRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAllOrdered(Expression<Func<TEntity, bool>> predicate, IOrdering<TEntity> ordering);
        IEnumerable<TEntity> FindAllPaged(Expression<Func<TEntity, bool>> predicate, IPaging<TEntity> paging);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
