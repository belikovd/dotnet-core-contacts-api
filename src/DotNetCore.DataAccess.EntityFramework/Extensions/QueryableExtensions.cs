using DotNetCore.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetCore.DataAccess.EntityFramework.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Sort<TEntity>(
            this IQueryable<TEntity> query, 
            IOrdering<TEntity> ordering,
            Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includePaths) where TEntity : class, new()
        {
            if (query == null)
                return Enumerable.Empty<TEntity>().AsQueryable();

            foreach (var path in includePaths)
            {
                query.Include(path);
            }

            return Sort(query, ordering, predicate);
        }

        public static IQueryable<TOut> Sort<TEntity, TOut>(
            this IQueryable<TEntity> query,
            IOrdering<TEntity> ordering,
            Expression<Func<TEntity, TOut>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includePaths) where TEntity : class, new()
        {
            if (query == null)
                return Enumerable.Empty<TOut>().AsQueryable();

            foreach (var path in includePaths)
            {
                query.Include(path);
            }

            var orderedQuery = Sort(query, ordering, predicate);

            return orderedQuery.Select(selector);
        }

        public static IQueryable<TEntity> Paginate<TEntity>(
            this IQueryable<TEntity> query, 
            IPaging<TEntity> paging,
            Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includePaths) where TEntity : class, new()
        {
            if (query == null)
                return Enumerable.Empty<TEntity>().AsQueryable();

            foreach (var path in includePaths)
            {
                query.Include(path);
            }

            var orderedQuery = Sort(query, paging, predicate);
            var result = orderedQuery
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return result;
        }

        public static IQueryable<TOut> Paginate<TOut, TEntity>(
            this IQueryable<TEntity> query,
            IPaging<TEntity> paging,
            Expression<Func<TEntity, TOut>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includePaths) where TEntity : class, new()
        {
            if (query == null)
                return Enumerable.Empty<TOut>().AsQueryable();

            foreach (var path in includePaths)
            {
                query.Include(path);
            }

            var sortedQuery = Sort(query, paging, predicate);
            var result = sortedQuery
                .Skip((paging.PageNumber - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(selector);

            return result;
        }

        internal static IQueryable<TEntity> Sort<TEntity>(
            IQueryable<TEntity> query, 
            IOrdering<TEntity> ordering, 
            Expression<Func<TEntity, bool>> predicate = null) where TEntity : class, new()
        {
            var filteredQuery = predicate == null ? query : query.Where(predicate);

            if (ordering.Property == null)
                throw new InvalidOperationException($"The {nameof(IOrdering<TEntity>.Property)} is required.");

            return ordering.IsDescending
                ? filteredQuery.OrderByDescending(ordering.Property)
                : filteredQuery.OrderBy(ordering.Property);
        }
    }
}
