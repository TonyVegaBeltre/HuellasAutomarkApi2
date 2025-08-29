using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using HuellasAutomarkAPI.Application.Dto;
using AutoMapper;

namespace HuellasAutomarkAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : GenericController<Client,ClientDto>
    {

        public ClientsController(IGeneric<Client> repository, IMapper mapper) : base(repository,mapper)
        {

        }


    }
}
