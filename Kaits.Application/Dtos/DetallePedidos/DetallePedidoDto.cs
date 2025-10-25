using Kaits.Application.Dtos.Pedidos;
using Kaits.Application.Dtos.Productos;

namespace Kaits.Application.Dtos.DetallePedidos
{
    public class DetallePedidoDto
    {
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public ProductoDto Producto { get; set; }
        public PedidoDto Pedido { get; set; }
    }
}
