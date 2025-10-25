using Kaits.Application.Dtos.Clientes;

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
