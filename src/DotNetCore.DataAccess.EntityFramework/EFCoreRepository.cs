using DotNetCore.DataAccess.Abstractions;
using DotNetCore.DataAccess.Abstractions.Repositories;
using DotNetCore.DataAccess.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetCore.DataAccess.EntityFramework
{
    public abstract class EFCoreRepository<TEntity> : IRelationalRepository<TEntity> where TEntity : class, new()
    {
        protected DbContext Context { get; }
        protected DbSet<TEntity> DbSet { get; }

        public EFCoreRepository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);

            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var query = DbSet.AsQueryable();

            var entities = query.Where(predicate);

            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Deleted;
            }

            DbSet.RemoveRange(entities);
        }

        public IEnumerable<TOut> FinaAllPagedWithRelations<TOut>(Expression<Func<TEntity, bool>> predicate, IPaging<TEntity> paging, Expression<Func<TEntity, TOut>> selector, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            var result = query.Paginate(paging, selector, predicate, includePaths);

            return result.ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> FindAllOrdered(Expression<Func<TEntity, bool>> predicate, IOrdering<TEntity> ordering)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            var result = query.Sort(ordering, predicate);

            return result.ToList();
        }

        public IEnumerable<TEntity> FindAllOrderedWithRelations(Expression<Func<TEntity, bool>> predicate, IOrdering<TEntity> ordering, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            var result = query.Sort(ordering, predicate, includePaths);

            return result.ToList();
        }

        public IEnumerable<TOut> FindAllOrderedWithRelations<TOut>(Expression<Func<TEntity, bool>> predicate, IOrdering<TEntity> ordering, Expression<Func<TEntity, TOut>> selector, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            var result = query.Sort(ordering, selector, predicate, includePaths);

            return result.ToList();
        }

        public IEnumerable<TEntity> FindAllPaged(Expression<Func<TEntity, bool>> predicate, IPaging<TEntity> paging)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            var result = query.Paginate(paging, predicate);

            return result.ToList();
        }

        public IEnumerable<TEntity> FindAllPagedWithRelations(Expression<Func<TEntity, bool>> predicate, IPaging<TEntity> paging, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            var result = query.Paginate(paging, predicate, includePaths);

            return result.ToList();
        }

        public IEnumerable<TEntity> FindAllWithRelations(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();

            foreach (var path in includePaths)
                query.Include(path);

            return query.Where(predicate).ToList();
        }

        public IEnumerable<TOut> FindAllWithRelations<TOut>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOut>> selector, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();

            foreach (var path in includePaths)
                query.Include(path);

            return query.Where(predicate).Select(selector).ToList();
        }

        public TEntity FindWithRelations(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePaths)
        {
            var query = DbSet.AsNoTracking().AsQueryable();

            foreach (var path in includePaths)
                query.Include(path);

            return query.FirstOrDefault(predicate);
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }

            DbSet.UpdateRange(entities);
        }
    }

    public abstract class EFCoreRepository<TEntity, TKey> : EFCoreRepository<TEntity>, IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
    {
        public EFCoreRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(params TKey[] ids)
        {
            foreach (var id in ids)
            {
                var entity = new TEntity { Id = id };

                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public TEntity Get(TKey id)
        {
            return DbSet.Find(id);
        }
    }
}
