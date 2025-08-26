using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Interfaces.IApiResponse
{
    public interface IApiResponse<T>
    {
        bool Success { get; set; }
        int StatusCode { get; set; }
        T? Result { get; set; }
        List<string>? Errors { get; set; }
    }
}
