using DotNetCore.Common;
using DotNetCore.Common.Abstractions;
using DotNetCore.Common.Extensions;
using DotNetCore.WebApi.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetCore.WebApi.Core
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly ISettings _settings;

        public ApiControllerBase(ISettings settings)
        {
            _settings = settings;
        }

        protected IActionResult OkOrBadRequestResult(IApiResult apiResult)
        {
            var errorResult = GetErrorResult(apiResult);

            return errorResult ?? Ok(apiResult.Data);
        }

        protected IActionResult HttpErrorResult(Exception ex)
        {
            if (ex == null)
            {
                AppTrace.Error("Exception is null. Generic error result is being returned.");
                return new ObjectResult(new ApiFailure()) { StatusCode = StatusCodes.Status500InternalServerError };
            }

            ex.Trace();

            bool showDetails = _settings.ExposeExceptionDetails;

            return new ObjectResult(showDetails ? new ApiFailureOnException(ex) : new ApiFailure())
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        protected IActionResult GetErrorResult(IApiResult apiResult)
        {
            if (apiResult == null)
                return HttpErrorResult(new Exception());

            if (apiResult.IsSuccessful)
                return null;

            var failure = new ApiFailure(apiResult);

            return BadRequest(failure);
        }
    }
}
