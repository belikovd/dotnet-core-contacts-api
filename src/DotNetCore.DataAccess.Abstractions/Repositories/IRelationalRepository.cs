using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotNetCore.DataAccess.Abstractions.Repositories
{
    public interface IRelationalRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, new()
    {
        TEntity FindWithRelations(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePaths);
        IEnumerable<TEntity> FindAllWithRelations(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePaths);
        IEnumerable<TOut> FindAllWithRelations<TOut>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOut>> selector, params Expression<Func<TEntity, object>>[] includePaths);
        IEnumerable<TEntity> FindAllOrderedWithRelations(Expression<Func<TEntity, bool>> predicate, IOrdering<TEntity> ordering, params Expression<Func<TEntity, object>>[] includePaths);
        IEnumerable<TOut> FindAllOrderedWithRelations<TOut>(Expression<Func<TEntity, bool>> predicate, IOrdering<TEntity> ordering, Expression<Func<TEntity, TOut>> selector, params Expression<Func<TEntity, object>>[] includePaths);
        IEnumerable<TEntity> FindAllPagedWithRelations(Expression<Func<TEntity, bool>> predicate, IPaging<TEntity> paging, params Expression<Func<TEntity, object>>[] includePaths);
        IEnumerable<TOut> FinaAllPagedWithRelations<TOut>(Expression<Func<TEntity, bool>> predicate, IPaging<TEntity> paging, Expression<Func<TEntity, TOut>> selector, params Expression<Func<TEntity, object>>[] includePaths);
    }
}
