using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Kaits.Infrastructure.Cores.Contexts;
using Kaits.Infrastructure.Cores.Persistences;

namespace Kaits.Infrastructure.Persistences
{
    public class DetallePedidoRepository : CrudRepository<DetallePedido, int>, IDetallePedidoRepository
    {
        public DetallePedidoRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
