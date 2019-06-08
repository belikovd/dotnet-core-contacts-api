namespace DotNetCore.WebApi.Core.Models
{
    public class ApiError
    {
        public string[] ErrorMessages { get; set; }

        public ApiError(params string[] errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
