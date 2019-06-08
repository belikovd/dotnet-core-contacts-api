using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.Common.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Returns the value indicating whether specified <paramref name="source"/> is null or contains no elements.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of elements in the sequence.
        /// </typeparam>
        /// <param name="source">
        ///     Source sequence.
        /// </param>
        /// <returns>
        ///     <see cref="bool"/>
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}
