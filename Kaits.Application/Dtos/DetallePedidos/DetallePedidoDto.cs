using Kaits.Application.Dtos.Pedidos;
using Kaits.Application.Dtos.Productos;

namespace Kaits.Application.Dtos.DetallePedidos
{
    public class DetallePedidoDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Estado { get; set; }

        public ProductoDto Producto { get; set; }
        public PedidoDto Pedido { get; set; }
    }
}
