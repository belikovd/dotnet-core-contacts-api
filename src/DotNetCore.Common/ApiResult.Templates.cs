using DotNetCore.Common.Abstractions;
using System.Net;

namespace DotNetCore.Common
{
    public partial class ApiResult
    {
        public static IApiResult Success()
        {
            return new ApiResult();
        }

        public static IApiResult Success(object data)
        {
            return new ApiResult(true, data: data);
        }

        public static IApiResult Fail()
        {
            return new ApiResult(false);
        }

        public static IApiResult Fail(params string[] errors)
        {
            return new ApiResult(false, null, errors);
        }

        public static IApiResult Fail(object dataOrFailureState, params string[] errors)
        {
            return new ApiResult(false, dataOrFailureState, errors);
        }

        public static IApiResult HttpOk()
        {
            return new ApiResult(HttpStatusCode.OK);
        }

        public static IApiResult HttpOk(object data)
        {
            return new ApiResult(HttpStatusCode.OK, data: data);
        }

        public static IApiResult HttpNoContent()
        {
            return new ApiResult(HttpStatusCode.NoContent);
        }

        public static IApiResult HttpCreated(object data)
        {
            return new ApiResult(HttpStatusCode.Created, data);
        }

        public static IApiResult HttpBadRequest(params string[] errors)
        {
            return new ApiResult(HttpStatusCode.BadRequest, null, errors);
        }

        public static IApiResult HttpBadRequest(object dataOrFailureState, params string[] errors)
        {
            return new ApiResult(HttpStatusCode.BadRequest, dataOrFailureState, errors);
        }

        public static IApiResult HttpNotFound(params string[] errors)
        {
            return new ApiResult(HttpStatusCode.NotFound, errors: errors);
        }

        public static IApiResult HttpNotFound(object dataOrFailureState, params string[] errors)
        {
            return new ApiResult(HttpStatusCode.NotFound, dataOrFailureState, errors);
        }

        public static IApiResult HttpUnauthorized(params string[] errors)
        {
            return new ApiResult(HttpStatusCode.Unauthorized, errors: errors);
        }

        public static IApiResult HttpForbidden(params string[] errors)
        {
            return new ApiResult(HttpStatusCode.Forbidden, errors: errors);
        }

        public static IApiResult HttpBadGateway(params string[] errors)
        {
            return new ApiResult(HttpStatusCode.BadGateway, errors: errors);
        }

        public static IApiResult HttpServerError(params string[] errors)
        {
            return new ApiResult(HttpStatusCode.InternalServerError, errors: errors);
        }
    }
}
