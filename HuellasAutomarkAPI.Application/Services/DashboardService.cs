using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Services
{
    public class DashboardService 
    {
        private readonly IGeneric<Client> _client;
        private readonly IGeneric<Campaign> _campaign;
        private readonly IGeneric<ClientCampaign> _clientCampaign;
        public DashboardService(IGeneric<Client> client, IGeneric<Campaign> campaign, IGeneric<ClientCampaign> clientCampaign) 
        { 
            _client = client;
            _campaign = campaign;
            _clientCampaign = clientCampaign;
        }


        public async Task<Dashboard> GetDashboardAsync()
        {
            try
            {
                int totalClients =  await  _campaign.Query().CountAsync(c => c.IsActive);
                int totalCampaigns = await _campaign.Query().CountAsync(c => c.IsActive);
                var clientsByCity = await _client.Query()
                    .Where(c => c.IsActive)
                    .GroupBy(c => c.City.Name)
                    .Select(g => new {City = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.City, x => x.Count);
                var clientsByGender = await _client.Query()
                    .Where(c => c.IsActive)
                    .GroupBy(c => c.Gender.Name)
                    .Select(g => new { Gender = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Gender, x => x.Count);
                var totalClientsByCampaign = await _clientCampaign.Query()
                    .Where(c => c.IsActive)
                    .GroupBy(c => c.Campaign.Title)
                    .Select(g => new { Campaign = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Campaign, x => x.Count);



                var dashboard = new Dashboard
                {
                    TotalClients = totalClients,
                    TotalCampaigns = totalCampaigns,
                    ClientsByCity = clientsByCity,
                    ClientsByGender = clientsByGender,
                    TotalClientsByCampaign = totalClientsByCampaign
                };

                return dashboard;
               }catch(Exception ex)
                { throw new Exception("Ha ocurrido un error al obtener el dashboard: ", ex); }
            }
    }
}
