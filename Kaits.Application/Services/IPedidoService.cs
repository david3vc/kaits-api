using Kaits.Application.Cores.Services;
using Kaits.Application.Dtos.Pedidos;

namespace Kaits.Application.Services
{
    public interface IPedidoService : ICrudService<PedidoDto, PedidoSaveDto, int>
    {
    }
}
