using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Kaits.Infrastructure.Cores.Contexts;
using Kaits.Infrastructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Infrastructure.Persistences
{
    public class PedidoRepository : CrudRepository<Pedido, int>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
