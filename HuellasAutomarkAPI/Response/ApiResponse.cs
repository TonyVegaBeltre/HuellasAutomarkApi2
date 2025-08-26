using HuellasAutomarkAPI.Application.Interfaces.IApiResponse;
using HuellasAutomarkAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Domain.Entities.ApiResponse
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public T? Result { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResponse<T> SuccessResponse(T Result)
            => new() { Success = true, StatusCode = 200, Result = Result };

        public static ApiResponse<T> ErrorResponse(List<string>? errors = null)
            => new() { Success = false, Errors = errors };

        public IResult ToResult() => new ApiResponseResult<T>(this);
    }
}
