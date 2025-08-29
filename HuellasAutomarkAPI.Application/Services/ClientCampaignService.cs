using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Application.Dto;
using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuellasAutomarkAPI.Application.Interfaces.Mail;

namespace HuellasAutomarkAPI.Application.Services
{
    public class ClientCampaignService : IClientCampaign
    {
        private readonly IGeneric<Client> _client;
        private readonly IGeneric<Campaign> _campaign;
        private readonly IGeneric<State> _state;
        private readonly IGeneric<ClientCampaign> _clientCampaign;
        private readonly IMail _mail;
        public ClientCampaignService(IGeneric<Client> client, IGeneric<Campaign> campaign, 
                                       IGeneric<State> state, IGeneric<ClientCampaign> clientCampaign,
                                       IMail mail) 
        { 
            _client = client;
            _campaign = campaign;
            _state = state;
            _clientCampaign = clientCampaign;
            _mail = mail;
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
                var isAdded = await _clientCampaign.AddAsync(clientCampaign);

                if (isAdded)
                {
                    var client = await _client.GetByIdAsync(clientId);
                    var campaign = await _campaign.GetByIdAsync(campaignId);
                    var htmlPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\wwwroot\\html\\MailTemplate\\AddClientCampaign.html";
                    var logoPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\wwwroot\\images\\HuellasLogo.jpeg";
                    await _mail.SendEmailAsync(new MailMessageDto
                    {
                        ToEmail = client.Email,
                        Subject = "¡Nueva Campaña Asignada!",
                        ClientName = client.Name + " " + client.LastName,
                        CampaignName = campaign.Title,
                        SendDate = SendDate,
                        Observations = observations,
                        HtmlPath = htmlPath,
                        LogoPath = logoPath
                    });
                }
                else { throw new Exception("No se pudo agregar el cliente a la campaña."); }

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al agregar el cliente a la campaña: " + ex.Message);

            }

        }

        public async Task<List<IEnumerable<GetClientCampaignDto>>> GetClientByCampaign(int clientId)
        {
            try
            {
                var ClientCampaign = from clc in await _clientCampaign.GetAllAsync()
                                     join ca in await _campaign.GetAllAsync() on clc.CampaignId equals ca.Id
                                     join cl in await _client.GetAllAsync() on clc.ClientId equals cl.Id
                                     join st in await _state.GetAllAsync() on clc.StateId equals st.Id
                                     where cl.Id == clientId && clc.IsActive == true
                                     select new GetClientCampaignDto
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
                var response = await _clientCampaign.RemoveAsync(IdClientCampaign);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al eliminar el cliente de la campaña: " + ex.Message);
            }
        }
    }
}
