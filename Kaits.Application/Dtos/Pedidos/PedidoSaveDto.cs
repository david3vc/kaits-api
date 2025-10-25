using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Application.Dtos.Pedidos
{
    public class PedidoSaveDto
    {
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
    }
}
