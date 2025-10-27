using Kaits.Application.Dtos.DetallePedidos;

namespace Kaits.Application.Dtos.Pedidos
{
    public class PedidoSaveDto
    {
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }

        public List<DetallePedidoSaveDto> DetallePedidoSaveDtos { get; set; }
    }
}
