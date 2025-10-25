using Kaits.Domain.Models;
using Kaits.Domain.Repositories;
using Kaits.Infrastructure.Cores.Contexts;
using Kaits.Infrastructure.Cores.Persistences;

namespace Kaits.Infrastructure.Persistences
{
    public class ProductoRepository : CrudRepository<Producto, int>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
