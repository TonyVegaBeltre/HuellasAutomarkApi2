using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HuellasAutomarkAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : GenericController<Client>
    {

        public ClientsController(IGeneric<Client> repository) : base(repository)
        {

        }


    }
}
