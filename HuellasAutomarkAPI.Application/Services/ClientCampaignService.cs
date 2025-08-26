using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Application.Dto;
using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Services
{
    public class ClientCampaignService : IClientCampaign
    {
        private readonly IGeneric<Client> _client;
        private readonly IGeneric<Campaign> _campaign;
        private readonly IGeneric<State> _state;
        private readonly IGeneric<ClientCampaign> _clientCampaign;
        public ClientCampaignService(IGeneric<Client> client, IGeneric<Campaign> campaign, IGeneric<State> state, IGeneric<ClientCampaign> clientCampaign) 
        { 
            _client = client;
            _campaign = campaign;
            _state = state;
            _clientCampaign = clientCampaign;
        }

        public async Task<bool> AddClientCampigns(int clientId, int campaignId,int stateId, DateTime SendDate, string observations)
        {
            try
            {

                var clientCampaign = new ClientCampaign
                {
                    ClientId = clientId,
                    CampaignId = campaignId,
                    StateId = stateId, 
                    SendDate = SendDate,
                    Observations = observations,
                    IsActive = true
                };
                await _clientCampaign.AddAsync(clientCampaign);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al agregar el cliente a la campaña: " + ex.Message);

            }

        }

        public async Task<List<IEnumerable<ClientCampaignDto>>> GetClientByCampaign(int clientId)
        {
            try
            {
                var ClientCampaign = from clc in await _clientCampaign.GetAllAsync()
                                     join ca in await _campaign.GetAllAsync() on clc.CampaignId equals ca.Id
                                     join cl in await _client.GetAllAsync() on clc.ClientId equals cl.Id
                                     join st in await _state.GetAllAsync() on clc.StateId equals st.Id
                                     where cl.Id == clientId && clc.IsActive == true
                                     select new ClientCampaignDto
                                     {
                                         Id = clc.Id,
                                         ClientId = clientId,
                                         ClientName = cl.Name + " " + cl.LastName,
                                         CampaignId = ca.Id,
                                         CampaignName = ca.Title,
                                         StateId = clc.StateId,
                                         StateName = st.Name,
                                         SendDate = clc.SendDate,
                                         Observations = clc.Observations,
                                         IsActive = clc.IsActive
                                     };

                return [ClientCampaign];
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al obtener las campañas del cliente: " + ex.Message);
            }

        }

        public async Task<bool> RemoveClientFromCampaign(int IdClientCampaign)
        {
            try
            {
                var response = await _clientCampaign.DeleteAsync(IdClientCampaign);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al eliminar el cliente de la campaña: " + ex.Message);
            }
        }
    }
}
