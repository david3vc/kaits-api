using Kaits.Application.Dtos.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.Application.Dtos.Pedidos
{
    public class PedidoDto
    {
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }

        public ClienteDto Cliente { get; set; }
    }
}
