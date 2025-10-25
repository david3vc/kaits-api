using Kaits.Domain.Cores.Models;

namespace Kaits.Domain.Models
{
    public class DetallePedido : CoreModel<int>
    {
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
