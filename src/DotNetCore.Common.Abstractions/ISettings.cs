namespace DotNetCore.Common.Abstractions
{
    /// <summary>
    ///     Abstraction over common settings.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        ///     Gets or sets the value indicating whether an app is allowed to expose exception details.
        /// </summary>
        bool ExposeExceptionDetails { get; set; }
    }
}
