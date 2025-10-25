using Kaits.Application.Dtos.Clientes;
using Kaits.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kaits.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ClienteDto>> Get()
        {
            return await _clienteService.FindAllAsync();
        }

        // GET: api/values/2
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDto))]
        public async Task<Results<NotFound, Ok<ClienteDto>>> Get(int id)
        {
            var response = await _clienteService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
