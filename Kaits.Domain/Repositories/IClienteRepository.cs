using Kaits.Domain.Cores.Repositories;
using Kaits.Domain.Models;

namespace Kaits.Domain.Repositories
{
    public interface IClienteRepository : ICrudRepository<Cliente, int>
    {
    }
}
