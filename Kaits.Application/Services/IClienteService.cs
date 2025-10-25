using Kaits.Application.Cores.Services;
using Kaits.Application.Dtos.Clientes;

namespace Kaits.Application.Services
{
    public interface IClienteService : IQueryService<ClienteDto, int>
    {
    }
}
