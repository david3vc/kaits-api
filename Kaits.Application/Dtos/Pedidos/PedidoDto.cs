using Kaits.Application.Dtos.Clientes;

namespace Kaits.Application.Dtos.Pedidos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }

        public ClienteDto Cliente { get; set; }
    }
}
