using System.Collections.Generic;
using System.Net;

namespace DotNetCore.Common.Abstractions
{
    /// <summary>
    ///     Abstraction over API result.
    /// </summary>
    public interface IApiResult
    {
        #region "Properties"

        /// <summary>
        ///     Gets the data payload.
        /// </summary>
        object Data { get; }

        /// <summary>
        ///     Indicates whether the current instance represents a successful result.
        /// </summary>
        bool IsSuccessful { get; }

        /// <summary>
        ///     Gets the collection of errors related to the current result.
        /// </summary>
        IReadOnlyList<string> Errors { get; }

        /// <summary>
        ///     Gets a flatten represantation of the errors.
        /// </summary>
        string FlattenError { get; }

        /// <summary>
        ///     Gets the value of <see cref="HttpStatusCode"/> related to the current result.
        /// </summary>
        HttpStatusCode? StatusCode { get; }

        #endregion

        /// <summary>
        ///     Gets the data payload as the value of specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     Expected type of the value.
        /// </typeparam>
        /// <returns>
        ///     <typeparamref name="T"/>
        /// </returns>
        T GetData<T>();

        /// <summary>
        ///     Returns a value indicating whether the data payload is obtained and it match the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     Expected type of the value.
        /// </typeparam>
        /// <param name="result">
        ///     Value of <typeparamref name="T"/> type.
        /// </param>
        /// <returns>
        ///     <see cref="bool"/>
        /// </returns>
        bool TryGetData<T>(out T result);
    }
}
