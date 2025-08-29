using AutoMapper;
using HuellasAutomarkAPI.Application.Dto;
using HuellasAutomarkAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Client
            CreateMap<ClientDto, Client>(); // para hacer get
            CreateMap<Client, ClientDto>(); // para crear clientes con dto

            // ClientCampaign
            CreateMap<CreateClientCampaignDto, ClientCampaign>();
            CreateMap<ClientCampaign, GetClientCampaignDto>();

            // Campaign
            CreateMap<CampaignDto, Campaign>();
            CreateMap<Campaign, CampaignDto>();
        }
    }
}
