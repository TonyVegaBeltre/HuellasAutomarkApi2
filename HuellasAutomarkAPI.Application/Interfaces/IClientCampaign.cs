using HuellasAutomarkAPI.Domain.Entities;
using HuellasAutomarkAPI.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Interfaces
{
    public interface IClientCampaign
    {
        public Task<List<IEnumerable<ClientCampaignDto>>> GetClientByCampaign(int clientId);
        public Task<bool> AddClientCampigns(int clientId, int campaignId,int stateId, DateTime SendDate, string observations);
        public Task<bool> RemoveClientFromCampaign(int IdClientCampaign);
    }
}
