using Kaits.Application.Dtos.Productos;
using Kaits.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kaits.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ProductoDto>> Get()
        {
            return await _productoService.FindAllAsync();
        }

        // GET: api/values/2
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        public async Task<Results<NotFound, Ok<ProductoDto>>> Get(int id)
        {
            var response = await _productoService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
