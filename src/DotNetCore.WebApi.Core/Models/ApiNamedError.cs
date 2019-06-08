namespace DotNetCore.WebApi.Core.Models
{
    public class ApiNamedError : ApiError
    {
        public string Name { get; set; }

        public ApiNamedError(string name, params string[] errorMessages) : base(errorMessages)
        {
            Name = name;
        }
    }
}
