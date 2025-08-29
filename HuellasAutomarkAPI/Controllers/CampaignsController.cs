using AutoMapper;
using HuellasAutomarkAPI.Application.Dto;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HuellasAutomarkAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : GenericController<Campaign,CampaignDto>
    {

        public CampaignsController(IGeneric<Campaign> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
