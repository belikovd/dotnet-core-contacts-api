using DotNetCore.Common.Abstractions;
using DotNetCore.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DotNetCore.Common
{
    /// <summary>
    ///     Implements <see cref="IApiResult"/>.
    /// </summary>
    public partial class ApiResult : IApiResult
    {
        #region "Fields"

        private readonly List<string> _errors;

        #endregion

        #region "IApiResult - Properties"

        public object Data { get; private set; }

        public bool IsSuccessful { get; }

        public IReadOnlyList<string> Errors => _errors?.ToArray() ?? new string[0];

        public string FlattenError
        {
            get
            {
                if (_errors.IsNullOrEmpty())
                    return string.Empty;

                var sb = new StringBuilder();
                _errors.ForEach(_ => sb.Append(_));

                return sb.ToString();
            }
        }

        public HttpStatusCode? StatusCode { get; } = null;

        #endregion

        #region ".ctor"

        internal ApiResult()
        {
            _errors = new List<string>();

            Data = null;
            IsSuccessful = true;
        }

        internal ApiResult(bool isSuccessful, object data = null, params string[] errors) : this()
        {
            IsSuccessful = isSuccessful;
            Data = data;
            _errors.AddRange(errors);
        }

        internal ApiResult(HttpStatusCode statusCode, object data = null, params string[] errors) : this()
        {
            StatusCode = statusCode;
            IsSuccessful = (int)statusCode >= 200 && (int)statusCode <= 299;
            Data = data;

            _errors.AddRange(errors);
        }

        #endregion

        #region "IApiResult - Methods"

        public T GetData<T>()
        {
            if (Data == null)
                return default(T);

            return (T)Data;
        }

        public bool TryGetData<T>(out T result)
        {
            result = default(T);

            if (Data == null)
                return false;
            try
            {
                result = (T)Data;
                return true;
            }
            catch (Exception)
            {
            }

            return false;
        }

        #endregion
    }
}
