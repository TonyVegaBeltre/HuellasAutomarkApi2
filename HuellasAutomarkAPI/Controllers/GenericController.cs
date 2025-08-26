using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace HuellasAutomarkAPI.Controllers
{
    public class GenericController<T> : ControllerBase where T : class
    {
        readonly IGeneric<T> _repository;
        public GenericController(IGeneric<T> repository)
        {
            _repository = repository;
        }
        [HttpGet,Route("GetAll")]
        public virtual async Task<IResult> GetAllsAsync()
        {
            var entities = await _repository.GetAllAsync();
            return ApiResponse<object>.SuccessResponse(entities ?? new object()).ToResult();
        }

        [HttpGet,Route("GetById/{id}")]
        public virtual async Task<IResult> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return ApiResponse<object>.SuccessResponse(entity ?? new object()).ToResult();
        }

        [HttpPost, Route("Add")]

        public virtual async Task<IResult> AddProductAsync([FromBody] T entity)
        {
            var response = await _repository.AddAsync(entity);
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
        [HttpPut, Route("Modify/{id}")]

        public virtual async Task<IResult> UpdateAsync([FromBody] T entity)
        {
            var response = await _repository.UpdateAsync(entity);
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
        [HttpDelete, Route("GetById/{id}")]

        public virtual async Task<IResult> DeleteAsync(int id)
        {
            var response = await _repository.DeleteAsync(id);
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
    }
}
