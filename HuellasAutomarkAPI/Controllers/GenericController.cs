using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace HuellasAutomarkAPI.Controllers
{
    public class GenericController<T, TDto> : ControllerBase where T : class
    {
        readonly IGeneric<T> _repository;
        readonly IMapper _mapper;
        public GenericController(IGeneric<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        public virtual async Task<IResult> AddAsync([FromBody] TDto dto)
        {

            //var response =/* await _repository.AddAsync(entity);*/
            var entity = _mapper.Map<T>(dto);
            var response = await _repository.AddAsync(entity);
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
        [HttpPut, Route("Modify/{id}")]

        public virtual async Task<IResult> UpdateAsync([FromBody] TDto dto)
        {

            var entity = _mapper.Map<T>(dto);
            var response = await _repository.UpdateAsync(entity);
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
        [HttpDelete, Route("Remove/{id}")]

        public virtual async Task<IResult> RemoveAsync(int id)
        {
            var response = await _repository.RemoveAsync(id);
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
        [HttpGet, Route("GetAllActiveEntitiesAsync")]
        public virtual async Task<IResult> GetAllActiveEntitiesAsync()
        {
            var response = await _repository.GetAllActiveEntitiesAsync(_repository.Query());
            return ApiResponse<object>.SuccessResponse(response).ToResult();
        }
    }
}
