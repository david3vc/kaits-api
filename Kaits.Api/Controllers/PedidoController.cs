using Kaits.Api.Exceptions;
using Kaits.Application.Cores.Dtos;
using Kaits.Application.Dtos.Pedidos;
using Kaits.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kaits.Api.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<PedidoDto>> Get()
        {
            return await _pedidoService.FindAllAsync();
        }

        // GET: api/values/2
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoDto))]
        public async Task<Results<NotFound, Ok<PedidoDto>>> Get(int id)
        {
            var response = await _pedidoService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PedidoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<PedidoDto>>> Post([FromBody] PedidoSaveDto saveDto)
        {
            var response = await _pedidoService.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<PedidoDto> Put(int id, [FromBody] PedidoSaveDto saveDto)
        {
            return await _pedidoService.EditAsync(id, saveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<PedidoDto> Delete(int id)
        {
            return await _pedidoService.DisabledAsync(id);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<PageResponse<PedidoDto>> PaginatedSearch([FromQuery] PageRequest<PedidoFilterDto> request)
        {
            return await _pedidoService.FindAllPaginatedAsync(request);
        }
    }
}
