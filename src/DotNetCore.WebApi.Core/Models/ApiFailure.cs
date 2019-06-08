using DotNetCore.Common.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace DotNetCore.WebApi.Core.Models
{
    public class ApiFailure
    {
        protected const string RequestCannotBeProcessed = "The request cannot be processed.";

        public string Message { get; set; } = RequestCannotBeProcessed;
        public ApiError[] Errors { get; set; }

        public ApiFailure(IApiResult apiResult)
        {
            Errors = new[] { new ApiError(apiResult?.Errors?.ToArray() ?? new string[0]) };
        }

        public ApiFailure(ModelStateDictionary modelState)
        {
            Errors = modelState.Select(_ 
                => new ApiNamedError(_.Key, _.Value.Errors.Select(__ => __.ErrorMessage).ToArray()))
                .ToArray();
        }

        public ApiFailure(params string[] errors)
        {
            Errors = new[] { new ApiError(errors) };
        }
    }
}
