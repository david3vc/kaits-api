using Kaits.Application.Cores.Services;
using Kaits.Application.Dtos.Productos;

namespace Kaits.Application.Services
{
    public interface IProductoService : IQueryService<ProductoDto, int>
    {
    }
}
