using Kaits.Domain.Cores.Models;

namespace Kaits.Domain.Models
{
    public class Pedido : CoreModel<int>
    {
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
