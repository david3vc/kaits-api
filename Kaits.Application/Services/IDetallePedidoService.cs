using Kaits.Application.Cores.Services;
using Kaits.Application.Dtos.DetallePedidos;

namespace Kaits.Application.Services
{
    public interface IDetallePedidoService : ICrudService<DetallePedidoDto, DetallePedidoSaveDto, int>
    {
    }
}
