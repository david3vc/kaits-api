using Kaits.Domain.Cores.Repositories;
using Kaits.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Domain.Repositories
{
    public interface IProductoRepository : ICrudRepository<Producto, int>
    {
    }
}
