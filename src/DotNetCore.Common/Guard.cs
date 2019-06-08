using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.Common
{
    /// <summary>
    ///     Provides common and convenient methods to handle invalid object state.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        ///     Throws <see cref="ArgumentNullException"/> if specified <paramref name="value"/> is <see cref="null"/>.
        /// </summary>
        /// <param name="value">
        ///     Value to check.
        /// </param>
        /// <param name="parameterName">
        ///     Value parameter name.
        /// </param>
        public static void ThrowIfNull(object value, string parameterName)
        {
            if (value != null) return;

            throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        ///     Throws <see cref="ArgumentException"/> if specified <paramref name="value"/> represents the <see cref="null"/>, empty string or contains only whitespace characters.
        /// </summary>
        /// <param name="value">
        ///     Value to check.
        /// </param>
        /// <param name="parameterName">
        ///     Value parameter name.
        /// </param>
        public static void ThrowIfNullOrEmpty(string value, string parameterName)
        {
            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("The specified string has an invalid value.", parameterName);
        }

        /// <summary>
        ///     Throws <see cref="ArgumentException"/> if specified <paramref name="source"/> sequence is <see cref="null"/> or contains no elements.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of elements inside the sequence.
        /// </typeparam>
        /// <param name="source">
        ///     Source sequence.
        /// </param>
        /// <param name="parameterName">
        ///     Source parameter name.
        /// </param>
        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T> source, string parameterName)
        {
            if (source != null && source.Any()) return;

            throw new ArgumentException("The specified collection is empty or not initialized.", parameterName);
        }

        /// <summary>
        ///     Throws <see cref="ArgumentException"/> if specified <paramref name="value"/> represents a default value of its type.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the <paramref name="value"/>.
        /// </typeparam>
        /// <param name="value">
        ///     Value to check.
        /// </param>
        /// <param name="parameterName">
        ///     Value parameter name.
        /// </param>
        public static void ThrowIfDefaultValue<T>(T value, string parameterName)
        {
            ThrowIfNull(value, parameterName);

            if (!value.Equals(default(T))) return;

            throw new ArgumentException("The parameter is initialized with the default value.", parameterName);
        }

        /// <summary>
        ///     Throws <see cref="ArgumentException"/> if specified <paramref name="value"/> type is not equal to <typeparamref name="T"/>.
        ///     The check is not upcast.
        /// </summary>
        /// <typeparam name="T">
        ///     Expected value type.
        /// </typeparam>
        /// <param name="value">
        ///     Value to check.
        /// </param>
        /// <param name="parameterName">
        ///     Value parameter name.
        /// </param>
        public static void ThrowIfNotType<T>(object value, string parameterName)
        {
            ThrowIfNull(value, parameterName);

            if (value.GetType() == typeof(T)) return;

            throw new ArgumentException("The parameter has an invalid type.", parameterName);
        }
    }
}
