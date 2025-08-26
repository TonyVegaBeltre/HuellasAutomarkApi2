using HuellasAutomarkAPI.Application.Services;

using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities;
using HuellasAutomarkAPI.Domain.Entities.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace HuellasAutomarkAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientCampaignController : GenericController<ClientCampaign>
    {
        private readonly IClientCampaign _clientCampaign;
        public ClientCampaignController(IGeneric<ClientCampaign> repository, IClientCampaign clientCampaign) : base(repository)
        {
              _clientCampaign = clientCampaign;
        }
        [HttpGet,Route("GetClientToCampaign/{clientId}/Clients")]
        public virtual async Task<IResult> GetClientToCampaign(int clientId)
        {
            var entities = await _clientCampaign.GetClientByCampaign(clientId);
            return ApiResponse<object>.SuccessResponse(entities ?? new object()).ToResult();
        }

        [HttpPost, Route("AddClientToCampaign/{clientId}/Clients")]
        public virtual async Task<IResult> AddClientCampigns(int clientId, int campaignId, int stateId, DateTime SendDate, string observations)
        {
            var clientCampaignToAdd = await _clientCampaign.AddClientCampigns(clientId, campaignId,stateId, SendDate, observations);
            return ApiResponse<object>.SuccessResponse(clientCampaignToAdd).ToResult();
        }

        [HttpDelete, Route("RemoveClientFromCampaign/{IdClientCampaign}/Clients")]
        public virtual async Task<IResult> RemoveClientFromCampaign(int IdClientCampaign)
        {
            var clientCampignToRemove = await _clientCampaign.RemoveClientFromCampaign(IdClientCampaign);
            return ApiResponse<object>.SuccessResponse(clientCampignToRemove).ToResult();
        }

    }
}
