using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities;
using HuellasAutomarkAPI.Domain.Entities.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace HuellasAutomarkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;
        public DashboardController(DashboardService dashboardService) 
        {
            _dashboardService = dashboardService;
        }
        
        [HttpGet, Route("GetDashboard")]
        public virtual async Task<IResult> GetDashboardAsync()
        {
            var dashboard = await _dashboardService.GetDashboardAsync();
            return ApiResponse<object>.SuccessResponse(dashboard ?? new object()).ToResult();
        }
    }
}
