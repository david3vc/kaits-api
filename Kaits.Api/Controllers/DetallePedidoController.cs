using Kaits.Application.Dtos.DetallePedidos;
using Kaits.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kaits.Api.Controllers
{
    [Route("api/[controller]")]
    public class DetallePedidoController : Controller
    {
        private readonly IDetallePedidoService _detallePedidoService;

        public DetallePedidoController(IDetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<DetallePedidoDto>> Get()
        {
            return await _detallePedidoService.FindAllAsync();
        }

        // GET: api/values
        [HttpGet("FindAllByIdPedido/{id}")]
        public async Task<IEnumerable<DetallePedidoDto>> GetByIdPedido(int id)
        {
            return await _detallePedidoService.FindAllByIdPedidoAsync(id);
        }

        // GET: api/values/2
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetallePedidoDto))]
        public async Task<Results<NotFound, Ok<DetallePedidoDto>>> Get(int id)
        {
            var response = await _detallePedidoService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DetallePedidoDto))]
        public async Task<Results<BadRequest, CreatedAtRoute<DetallePedidoDto>>> Post([FromBody] DetallePedidoSaveDto saveDto)
        {
            var response = await _detallePedidoService.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<DetallePedidoDto> Put(int id, [FromBody] DetallePedidoSaveDto saveDto)
        {
            return await _detallePedidoService.EditAsync(id, saveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<DetallePedidoDto> Delete(int id)
        {
            return await _detallePedidoService.DisabledAsync(id);
        }
    }
}
