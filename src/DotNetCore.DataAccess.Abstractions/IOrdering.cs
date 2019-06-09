using System;
using System.Linq.Expressions;

namespace DotNetCore.DataAccess.Abstractions
{
    /// <summary>
    ///     Abstraction over ordering parameters.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IOrdering<TEntity> where TEntity : class, new()
    {
        /// <summary>
        ///     Gets an expression for property to order by.
        /// </summary>
        Expression<Func<TEntity, object>> Property { get; }

        /// <summary>
        ///     Gets a value indicating whether the ordering is performed in descending direction.
        /// </summary>
        bool IsDescending { get; }
    }
}
