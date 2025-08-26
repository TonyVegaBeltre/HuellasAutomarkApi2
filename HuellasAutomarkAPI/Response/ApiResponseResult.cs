using HuellasAutomarkAPI.Application.Interfaces.IApiResponse;

namespace HuellasAutomarkAPI.Response
{
    public class ApiResponseResult<T> : IResult
    {
        private readonly IApiResponse<T> _response;

        public ApiResponseResult(IApiResponse<T> response)
        {
            _response = response;
        }

        public Task ExecuteAsync(HttpContext httpContext)
        {
            var statusCode = _response.Success ? StatusCodes.Status200OK :
                             _response.Errors?.Any(e => e.Contains("not found", StringComparison.OrdinalIgnoreCase)) == true
                             ? StatusCodes.Status404NotFound : StatusCodes.Status400BadRequest;

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            return httpContext.Response.WriteAsJsonAsync(_response);
        }
    }
}
