using Kaits.Application.Cores.Services;
using Kaits.Application.Dtos.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Application.Services
{
    public interface IPedidoService : ICrudService<PedidoDto, PedidoSaveDto, int>
    {
    }
}
