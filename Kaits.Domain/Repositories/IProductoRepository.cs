using Kaits.Domain.Cores.Repositories;
using Kaits.Domain.Models;

namespace Kaits.Domain.Repositories
{
    public interface IProductoRepository : ICrudRepository<Producto, int>
    {
    }
}
