using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Kaits.Infrastructure.Cores.Contexts;
using Kaits.Infrastructure.Cores.Persistences;

namespace Kaits.Infrastructure.Persistences
{
    public class ClienteRepository : CrudRepository<Cliente, int>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
