using System;

namespace DotNetCore.WebApi.Core.Models
{
    public class ApiFailureOnException : ApiFailure
    {
        public string StackTrace { get; set; }

        public ApiFailureOnException(Exception ex)
        {
            Errors = new[] { new ApiError(ex.Message) };
            StackTrace = ex.StackTrace;
        }
    }
}
