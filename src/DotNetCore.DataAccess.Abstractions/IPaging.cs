namespace DotNetCore.DataAccess.Abstractions
{
    /// <summary>
    ///     Abstraction over paging parameters.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IPaging<TEntity> : IOrdering<TEntity> where TEntity : class, new()
    {
        /// <summary>
        ///     Gets the page number.
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        ///     Gets the page size.
        /// </summary>
        int PageSize { get; }
    }
}
