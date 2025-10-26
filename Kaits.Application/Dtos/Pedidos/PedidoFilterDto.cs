namespace Kaits.Application.Dtos.Pedidos
{
    public class PedidoFilterDto
    {
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Total { get; set; }
        public bool? Estado { get; set; }
    }
}
