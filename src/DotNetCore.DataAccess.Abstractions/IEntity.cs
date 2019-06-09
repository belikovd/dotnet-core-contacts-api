namespace DotNetCore.DataAccess.Abstractions
{
    /// <summary>
    ///     Abstraction over entity having a single key.
    /// </summary>
    /// <typeparam name="TKey">
    ///     Type of the key.
    /// </typeparam>
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
